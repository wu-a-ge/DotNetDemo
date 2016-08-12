/**
 * Sea.js 2.1.1 | seajs.org/LICENSE.md
 */
(function(global, undefined) {

// Avoid conflicting when `sea.js` is loaded multiple times
    if (global.seajs) {
        return;
    }

    var seajs = global.seajs = {
        // The current version of Sea.js being used
        version: "2.1.1"
    };
    var data = seajs.data = {}; /**
 * util-lang.js - The minimal language enhancement
 */

    function isType(type) {
        return function(obj) {
            return Object.prototype.toString.call(obj) === "[object " + type + "]";
        };
    }

    var isObject = isType("Object");
    var isString = isType("String");
    var isArray = Array.isArray || isType("Array");
    var isFunction = isType("Function");
    var _cid = 0;

    function cid() {
        return _cid++;
    }


/**
 * util-events.js - The minimal events support
 */

    var events = data.events = {}; // Bind event
    seajs.on = function(name, callback) {
        var list = events[name] || (events[name] = []);
        list.push(callback);
        return seajs;
    }; // Remove event. If `callback` is undefined, remove all callbacks for the
// event. If `event` and `callback` are both undefined, remove all callbacks
// for all events
    seajs.off = function(name, callback) {
        // Remove *all* events
        if (!(name || callback)) {
            events = data.events = {};
            return seajs;
        }

        var list = events[name];
        if (list) {
            if (callback) {
                for (var i = list.length - 1; i >= 0; i--) {
                    if (list[i] === callback) {
                        list.splice(i, 1);
                    }
                }
            } else {
                delete events[name];
            }
        }

        return seajs;
    }; // Emit event, firing all bound callbacks. Callbacks receive the same
// arguments as `emit` does, apart from the event name
    var emit = seajs.emit = function(name, data) {
        var list = events[name], fn;
        if (list) {
            // Copy callback lists to prevent modification
            list = list.slice(); // Execute event callbacks
            while ((fn = list.shift())) {
                fn(data);
            }
        }

        return seajs;
    }; /**
 * util-path.js - The utilities for operating path such as id, uri
 */

    var DIRNAME_RE = /[^?#]*\//;
    var DOT_RE = /\/\.\//g;
    var DOUBLE_DOT_RE = /\/[^/]+\/\.\.\//; // Extract the directory portion of a path
// dirname("a/b/c.js?t=123#xx/zz") ==> "a/b/"
// ref: http://jsperf.com/regex-vs-split/2

    function dirname(path) {
        return path.match(DIRNAME_RE)[0];
    }

// Canonicalize a path
// realpath("http://test.com/a//./b/../c") ==> "http://test.com/a/c"

    function realpath(path) {
        // /a/b/./c/./d ==> /a/b/c/d
        path = path.replace(DOT_RE, "/"); // a/b/c/../../d  ==>  a/b/../d  ==>  a/d
        while (path.match(DOUBLE_DOT_RE)) {
            path = path.replace(DOUBLE_DOT_RE, "/");
        }

        return path;
    }

// Normalize an id
// normalize("path/to/a") ==> "path/to/a.js"
// NOTICE: substring is faster than negative slice and RegExp

    function normalize(path) {
        var last = path.length - 1;
        var lastC = path.charAt(last); // If the uri ends with `#`, just return it without '#'
        if (lastC === "#") {
            return path.substring(0, last);
        }

        return (path.substring(last - 2) === ".js" ||
            path.indexOf("?") > 0 ||
            path.substring(last - 3) === ".css" ||
            lastC === "/") ? path : path + ".js";
    }


    var PATHS_RE = /^([^/:]+)(\/.+)$/;
    var VARS_RE = /{([^{]+)}/g;
    /**标识的别名*/
    function parseAlias(id) {
        var alias = data.alias;
        return alias && isString(alias[id]) ? alias[id] : id;
    }
    /**可以说是路径的别名*/
    function parsePaths(id) {
        var paths = data.paths;
        var m;
        if (paths && (m = id.match(PATHS_RE)) && isString(paths[m[1]])) {
            id = paths[m[1]] + m[2];
        }

        return id;
    }

    function parseVars(id) {
        var vars = data.vars;
        if (vars && id.indexOf("{") > -1) {
            id = id.replace(VARS_RE, function(m, key) {
                return isString(vars[key]) ? vars[key] : m;
            });
        }

        return id;
    }
    /**就是一个查找直接替换*/
    function parseMap(uri) {
        var map = data.map;
        var ret = uri;
        if (map) {
            for (var i = 0, len = map.length; i < len; i++) {
                var rule = map[i];
                ret = isFunction(rule) ?
                    (rule(uri) || uri) :
                    uri.replace(rule[0], rule[1]); // Only apply the first matched rule
                if (ret !== uri) break;//找到一个匹配就直接返回了
            }
        }

        return ret;
    }


    var ABSOLUTE_RE = /^\/\/.|:\//;
    var ROOT_DIR_RE = /^.*?\/\/.*?\//; /**
根据模块标识符返回它的绝对路径
@param {String} id 模块标识符
@param  {String} refUri 解决当前标识符时所需要参考的Uri路径
*/

    function addBase(id, refUri) {
        var ret;
        var first = id.charAt(0); // Absolute
        if (ABSOLUTE_RE.test(id)) {
            ret = id;
        }
            // Relative
        else if (first === ".") {
            ret = realpath((refUri ? dirname(refUri) : data.cwd) + id);
        }
            // Root
        else if (first === "/") {
            var m = data.cwd.match(ROOT_DIR_RE);
            ret = m ? m[0] + id.substring(1) : id;
        }
            // Top-level
        else {
            ret = data.base + id;
        }

        return ret;
    }

/**
将模块标识转换成uri的步骤
1.别名查找 2.路径查找 3.变量查找 4.添加文件后缀 5.最终转换成绝对uri 6.再映射Uri到其它的uri
*/

    function id2Uri(id, refUri) {
        if (!id) return "";
        id = parseAlias(id);
        id = parsePaths(id);
        id = parseVars(id);
        id = normalize(id);
        var uri = addBase(id, refUri);
        uri = parseMap(uri);
        return uri;
    }


    var doc = document;
    var loc = location;
    var cwd = dirname(loc.href);
    var scripts = doc.getElementsByTagName("script"); // Recommend to add `seajsnode` id for the `sea.js` script element
    var loaderScript = doc.getElementById("seajsnode") ||
        scripts[scripts.length - 1]; // When `sea.js` is inline, set loaderDir to current working directory
    var loaderDir = dirname(getScriptAbsoluteSrc(loaderScript) || cwd);

    function getScriptAbsoluteSrc(node) {
        return node.hasAttribute ? // non-IE6/7
            node.src :
            // see http://msdn.microsoft.com/en-us/library/ms536429(VS.85).aspx
            node.getAttribute("src", 4);
    }


/**
 * util-request.js - The utilities for requesting script and style files
 * ref: tests/research/load-js-css/test.html
 */

    var head = doc.getElementsByTagName("head")[0] || doc.documentElement;
    var baseElement = head.getElementsByTagName("base")[0];
    var IS_CSS_RE = /\.css(?:\?|$)/i;
    var READY_STATE_RE = /^(?:loaded|complete|undefined)$/;
    var currentlyAddingScript;
    var interactiveScript; // `onload` event is not supported in WebKit < 535.23 and Firefox < 9.0
// ref:
//  - https://bugs.webkit.org/show_activity.cgi?id=38995
//  - https://bugzilla.mozilla.org/show_bug.cgi?id=185236
//  - https://developer.mozilla.org/en/HTML/Element/link#Stylesheet_load_events
    var isOldWebKit = (navigator.userAgent
        .replace(/.*AppleWebKit\/(\d+)\..*/, "$1")) * 1 < 536; /**发起Uri请求*/

    function request(url, callback, charset) {
        var isCSS = IS_CSS_RE.test(url);
        var node = doc.createElement(isCSS ? "link" : "script");
        if (charset) {
            var cs = isFunction(charset) ? charset(url) : charset;
            if (cs) {
                node.charset = cs;
            }
        }
        //用节点添加回调事件处理函数
        addOnload(node, callback, isCSS);
        if (isCSS) {
            node.rel = "stylesheet";
            node.href = url;
        } else {
            node.async = true; //ie9及以前版本是不支持的
            node.src = url;
        }

        // For some cache cases in IE 6-8, the script executes IMMEDIATELY after
        // the end of the insert execution, so use `currentlyAddingScript` to
        // hold current node, for deriving url in `define` call
        currentlyAddingScript = node; // ref: #185 & http://dev.jquery.com/ticket/2709
        //当有base元素的时候只能将节点插入base元素前面在ie6中，好坑爹
        baseElement ?
            head.insertBefore(node, baseElement) :
            head.appendChild(node);
        currentlyAddingScript = null;
    }

    function addOnload(node, callback, isCSS) {
        var missingOnload = isCSS && (isOldWebKit || !("onload" in node)); // for Old WebKit and Old Firefox
        if (missingOnload) {
            setTimeout(function() {
                pollCss(node, callback);
            }, 1); // Begin after node insertion
            return;
        }

        node.onload = node.onerror = node.onreadystatechange = function() {
            if (READY_STATE_RE.test(node.readyState)) {

                // Ensure only run once and handle memory leak in IE
                node.onload = node.onerror = node.onreadystatechange = null; //先移出再回调，居然还可以使用移出脚本中的代码！我记得以前是不可以使用的啊？！
                // Remove the script to reduce memory leak
                if (!isCSS && !data.debug) {
                    head.removeChild(node);
                }

                // Dereference the node
                node = null;
                callback();
            }
        };
    }

    function pollCss(node, callback) {
        var sheet = node.sheet;
        var isLoaded; // for WebKit < 536
        if (isOldWebKit) {
            if (sheet) {
                isLoaded = true;
            }
        }
            // for Firefox < 9.0
        else if (sheet) {
            try {
                if (sheet.cssRules) {
                    isLoaded = true;
                }
            } catch(ex) {
                // The value of `ex.name` is changed from "NS_ERROR_DOM_SECURITY_ERR"
                // to "SecurityError" since Firefox 13.0. But Firefox is less than 9.0
                // in here, So it is ok to just rely on "NS_ERROR_DOM_SECURITY_ERR"
                if (ex.name === "NS_ERROR_DOM_SECURITY_ERR") {
                    isLoaded = true;
                }
            }
        }

        setTimeout(function() {
            if (isLoaded) {
                // Place callback here to give time for style rendering
                callback();
            } else {
                pollCss(node, callback);
            }
        }, 20);
    }

    function getCurrentScript() {
        if (currentlyAddingScript) {
            return currentlyAddingScript;
        }

        // For IE6-9 browsers, the script onload event may not fire right
        // after the script is evaluated. Kris Zyp found that it
        // could query the script nodes and the one that is in "interactive"
        // mode indicates the current script
        // ref: http://goo.gl/JHfFW
        if (interactiveScript && interactiveScript.readyState === "interactive") {
            return interactiveScript;
        }

        var scripts = head.getElementsByTagName("script");
        for (var i = scripts.length - 1; i >= 0; i--) {
            var script = scripts[i];
            if (script.readyState === "interactive") {
                interactiveScript = script;
                return interactiveScript;
            }
        }
    }


/**
 * util-deps.js - The parser for dependencies
 * ref: tests/research/parse-dependencies/test.html
 */

    var REQUIRE_RE = /"(?:\\"|[^"])*"|'(?:\\'|[^'])*'|\/\*[\S\s]*?\*\/|\/(?:\\\/|[^\/\r\n])+\/(?=[^\/])|\/\/.*|\.\s*require|(?:^|[^$])\brequire\s*\(\s*(["'])(.+?)\1\s*\)/g;
    var SLASH_RE = /\\\\/g;

    function parseDependencies(code) {
        var ret = [];
        code.replace(SLASH_RE, "")
            .replace(REQUIRE_RE, function(m, m1, m2) {
                if (m2) {
                    ret.push(m2);
                }
            });
        return ret;
    }


/**
 * module.js - The core of module loader
 */

    var cachedMods = seajs.cache = {};
    var anonymousMeta;
    var fetchingList = {};
    var fetchedList = {};
    var callbackList = {};
    var STATUS = Module.STATUS = {
        // 1 - The `module.uri` is being fetched
        FETCHING: 1,
        // 2 - The meta data has been saved to cachedMods
        SAVED: 2,
        // 3 - The `module.dependencies` are being loaded
        LOADING: 3,
        // 4 - The module are ready to execute
        LOADED: 4,
        // 5 - The module is being executed
        EXECUTING: 5,
        // 6 - The `module.exports` is available
        EXECUTED: 6
    };

    function Module(uri, deps) {
        this.uri = uri;
        this.dependencies = deps || [];
        this.exports = null;
        this.status = 0; // Who depends on me
        this._waitings = {}; // The number of unloaded dependencies
        this._remain = 0;
    }

// Resolve module.dependencies
/**解析当前模块的依赖模块*/
    Module.prototype.resolve = function() {
        var mod = this;
        var ids = mod.dependencies;
        var uris = [];
        for (var i = 0, len = ids.length; i < len; i++) {
            uris[i] = Module.resolve(ids[i], mod.uri);
        }
        return uris;
    }; // Load module.dependencies and fire onload when all done
/**解析执行当前模块的依赖并发起http请求，没有依赖直接执行onload方法*/
    Module.prototype.load = function() {
        var mod = this; // If the module is being loaded, just wait it onload call
        if (mod.status >= STATUS.LOADING) {
            return;
        }

        mod.status = STATUS.LOADING; // Emit `load` event for plugins such as combo plugin
        //解析当前模块所有依赖模块路径
        var uris = mod.resolve();
        emit("load", uris); //当前模块所依赖模块的数量
        var len = mod._remain = uris.length;
        var m; // Initialize modules and register waitings
        //初始化所有模块并将当前模块注册时依赖模块的等待列表
        for (var i = 0; i < len; i++) {
            m = Module.get(uris[i]); //当前模块正在等待依赖模块加载完成，在依赖模块中的waitings数组将当前模块的uri作为键，值为等待的数量
            if (m.status < STATUS.LOADED) {
                // Maybe duplicate
                m._waitings[mod.uri] = (m._waitings[mod.uri] || 0) + 1;
            }
                //如果依赖模块状态已经加载完成，那么剩余数减1
            else {
                mod._remain--;
            }
        }
        //如果所有依赖完成，执行当前模块
        if (mod._remain === 0) {
            mod.onload();
            return;
        }

        // Begin parallel loading
        /**当前模块的依赖是并发执行的，不是一个一个加载的*/
        var requestCache = {};
        for (i = 0; i < len; i++) {
            m = cachedMods[uris[i]]; //如果当前模块还没有进入获取列表，添加入获取列表！这样可以防止重复请求模块
            if (m.status < STATUS.FETCHING) {
                m.fetch(requestCache);
            } else if (m.status === STATUS.SAVED) {
                m.load();
            }
        }

        // Send all requests at last to avoid cache bug in IE6-9. Issues#808
        for (var requestUri in requestCache) {
            if (requestCache.hasOwnProperty(requestUri)) {
                requestCache[requestUri]();
            }
        }
    }; // Call this method when module is loaded
    //模块的完成执行函数，这里会调用回调以及通知等待模块
    Module.prototype.onload = function() {
        var mod = this;
        mod.status = STATUS.LOADED;
        if (mod.callback) {
            mod.callback();
        }

        // Notify waiting modules to fire onload
        var waitings = mod._waitings;
        var uri, m;
        for (uri in waitings) {
            if (waitings.hasOwnProperty(uri)) {
                //等待模块的等待计数减一，如果等待计数为0就执行它的完成执行函数
                m = cachedMods[uri];
                m._remain -= waitings[uri];
                if (m._remain === 0) {
                    m.onload();
                }
            }
        }

        // Reduce memory taken
        delete mod._waitings;
        delete mod._remain;
    }; // Fetch a module
    Module.prototype.fetch = function(requestCache) {
        var mod = this;
        var uri = mod.uri; //将当前模块状态设置为正在获取
        mod.status = STATUS.FETCHING; // Emit `fetch` event for plugins such as combo plugin
        var emitData = { uri: uri };
        emit("fetch", emitData);
        var requestUri = emitData.requestUri || uri; // Empty uri or a non-CMD module
        //对于已经获取到的模块直接执行
        if (!requestUri || fetchedList[requestUri]) {
            mod.load();
            return;
        }
        //如果当前uri已经在正在获取列表中(也即多个模块需要当前模块，而当前模块正在请求加载中)，那么将当前模块放入回调列表
        if (fetchingList[requestUri]) {
            callbackList[requestUri].push(mod);
            return;
        }
        //当前模块放入正在获取列表和回调列表
        fetchingList[requestUri] = true;
        callbackList[requestUri] = [mod]; // Emit `request` event for plugins such as text plugin
        emit("request", emitData = {
            uri: uri,
            requestUri: requestUri,
            onRequest: onRequest,
            charset: data.charset
        }); //设置当前模块的请求方法
        if (!emitData.requested) {
            requestCache ?
                requestCache[emitData.requestUri] = sendRequest :
                sendRequest();
        }

        function sendRequest() {
            request(emitData.requestUri, emitData.onRequest, emitData.charset);
        }

/**脚本加载完了后执行此方法*/

        function onRequest() {
            delete fetchingList[requestUri]; //删除正在获取列表
            fetchedList[requestUri] = true; //这个列表是个缓存，后序的请求会优先判断这里是否已经存在

            // Save meta data of anonymous module
            if (anonymousMeta) {
                Module.save(uri, anonymousMeta);
                anonymousMeta = null;
            }

            // Call callbacks
            var m, mods = callbackList[requestUri];
            delete callbackList[requestUri]; //删除回调列表
            while ((m = mods.shift())) m.load(); //执行回调列表中的所有的模块load方法
        }
    }; // Execute a module
//执行一个模块
    Module.prototype.exec = function() {
        var mod = this; // When module is executed, DO NOT execute it again. When module
        // is being executed, just return `module.exports` too, for avoiding
        // circularly calling
        //避免模块重复执行，保证其只执行一次
        if (mod.status >= STATUS.EXECUTING) {
            return mod.exports;
        }

        mod.status = STATUS.EXECUTING; // Create require
        var uri = mod.uri; //从这里可以看出此方法并不会发起一个请求，而只是执行模块对象

        function require(id) {
            return Module.get(require.resolve(id)).exec();
        }

//依据当前模块的路径来解析一个指定的模块的路径
        require.resolve = function(id) {
            return Module.resolve(id, uri);
        }; //这里可能会发起http请求，因为如果指定的依赖是已经加载过的肯定不会发起请示，如果没有请求过，肯定会有http请求
        require.async = function(ids, callback) {
            Module.use(ids, callback, uri + "_async_" + cid());
            return require;
        }; // Exec factory
        var factory = mod.factory; //执行模块的构造函数，返回其导出模块对象
        var exports = isFunction(factory) ?
            factory(require, mod.exports = {}, mod) :
            factory;
        if (exports === undefined) {
            exports = mod.exports;
        }

        // Emit `error` event
        if (exports === null && !IS_CSS_RE.test(uri)) {
            emit("error", mod);
        }

        // Reduce memory leak
        delete mod.factory;
        mod.exports = exports;
        mod.status = STATUS.EXECUTED; // Emit `exec` event
        emit("exec", mod);
        return exports;
    }; 
    // Resolve id to uri
    Module.resolve = function(id, refUri) {
        // Emit `resolve` event for plugins such as text plugin
        var emitData = { id: id, refUri: refUri };
        emit("resolve", emitData);
        return emitData.uri || id2Uri(emitData.id, refUri);
    }; 
    // Define a module
    Module.define = function(id, deps, factory) {
        var argsLen = arguments.length; // define(factory)
        if (argsLen === 1) {
            factory = id;
            id = undefined;
        } else if (argsLen === 2) {
            factory = deps; // define(deps, factory)
            if (isArray(id)) {
                deps = id;
                id = undefined;
            }
                // define(id, factory)
            else {
                deps = undefined;
            }
        }
        //没有依赖或依赖不是一个数组，而只有构造函数，那么就从这个函数体中解析出它的依赖
        //也即在调用require方法的代码中解析出当前模块的依赖
        // Parse dependencies according to the module factory code
        if (!isArray(deps) && isFunction(factory)) {
            deps = parseDependencies(factory.toString());
        }
        //模块元数据
        var meta = {
            id: id,
            uri: Module.resolve(id),
            deps: deps,
            factory: factory
        }; // Try to derive uri in IE6-9 for anonymous modules
        //定义模块时没有指定当前模块的id(这是很经常的)，针对ie进行特殊处理来提取当前模块的uri
        //其它浏览器把当前模块当作一个匿名模块处理，在script的onload事件的回调中处理onRequest
        if (!meta.uri && doc.attachEvent) {
            var script = getCurrentScript();
            if (script) {
                meta.uri = script.src;
            }

            // NOTE: If the id-deriving methods above is failed, then falls back
            // to use onload event to get the uri
        }

        // Emit `define` event, used in nocache plugin, seajs node version etc
        emit("define", meta);
        meta.uri ? Module.save(meta.uri, meta) :
            // Save information for "saving" work in the script onload event
            anonymousMeta = meta;
    }; 
    // Save meta data to cachedMods
//保存模块的元数据到模块对象中
    Module.save = function(uri, meta) {
        var mod = Module.get(uri); // Do NOT override already saved modules
        if (mod.status < STATUS.SAVED) {
            mod.id = meta.id || uri;
            mod.dependencies = meta.deps || [];
            mod.factory = meta.factory;
            mod.status = STATUS.SAVED;
        }
    }; 
    // Get an existed module or create a new one
//通过给定的模块标识和当前模块的依赖取得已经在缓存中的模块对象或者创建一个模块
    Module.get = function(uri, deps) {
        return cachedMods[uri] || (cachedMods[uri] = new Module(uri, deps));
    }; 
    // Use function is equal to load a anonymous module
/**
加载一个指定的模块，这个方法使用来加载匿名模块,即uri都不是一个真正的路径，实际是为了加载匿名模块的依赖模块
@param {string} ids当前模块的依赖模块标识
@param {functin} callback 当前模块载入完成后的回调方法
@param {string} uri 当前模块的路径
*/
    Module.use = function(ids, callback, uri) {
        var mod = Module.get(uri, isArray(ids) ? ids : [ids]); /**将依赖模块按依赖顺序传入的当前模块的回调函数*/
        mod.callback = function() {
            var exports = [];
            var uris = mod.resolve(); //这里会执行每一个模块
            for (var i = 0, len = uris.length; i < len; i++) {
                exports[i] = cachedMods[uris[i]].exec();
            }

            if (callback) {
                callback.apply(global, exports);
            }

            delete mod.callback;
        };
        mod.load();
    }; 
    // Load preload modules before all other modules
    Module.preload = function(callback) {
        var preloadMods = data.preload;
        var len = preloadMods.length;
        if (len) {
            Module.use(preloadMods, function() {
                // Remove the loaded preload modules
                preloadMods.splice(0, len); // Allow preload modules to add new preload modules
                Module.preload(callback);
            }, data.cwd + "_preload_" + cid());
        } else {
            callback();
        }
    }; // Public API
//只适合页面使用来加载模块    
/**这个方法将当前页面当成一个模块，而传入的标识符当前依赖模块处理的*/
    seajs.use = function(ids, callback) {
        Module.preload(function() {
            Module.use(ids, callback, data.cwd + "_use_" + cid());
        });
        return seajs;
    };
    Module.define.cmd = {};
    global.define = Module.define; // For Developers 以下是开发人员使用

    seajs.Module = Module;
    data.fetchedList = fetchedList;
    data.cid = cid;
    seajs.resolve = id2Uri;
    seajs.require = function(id) {
        return (cachedMods[Module.resolve(id)] || {}).exports;
    }; 
    /**
 * config.js - The configuration for the loader
 */

    var BASE_RE = /^(.+?\/)(\?\?)?(seajs\/)+/; // The root path to use for id2uri parsing
// If loaderUri is `http://test.com/libs/seajs/[??][seajs/1.2.3/]sea.js`, the
// baseUri should be `http://test.com/libs/`
    data.base = (loaderDir.match(BASE_RE) || ["", loaderDir])[1]; // The loader directory
    data.dir = loaderDir; 
    // The current working directory
    data.cwd = cwd; 
    // The charset for requesting files
    data.charset = "utf-8"; 
    //处理插件在uri中的情况
    // Modules that are needed to load before all other modules
    data.preload = (function() {
        var plugins = []; // Convert `seajs-xxx` to `seajs-xxx=1`
        // NOTE: use `seajs-xxx=1` flag in uri or cookie to preload `seajs-xxx`
        var str = loc.search.replace(/(seajs-\w+)(&|$)/g, "$1=1$2"); // Add cookie string
        str += " " + doc.cookie; // Exclude seajs-xxx=0
        str.replace(/(seajs-\w+)=1/g, function(m, name) {
            plugins.push(name);
        });
        return plugins;
    })(); 
    // data.alias - An object containing shorthands of module id
// data.paths - An object containing path shorthands in module id
// data.vars - The {xxx} variables in module id
// data.map - An array containing rules to map module uri
// data.debug - Debug mode. The default value is false

    seajs.config = function(configData) {

        for (var key in configData) {
            var curr = configData[key];
            var prev = data[key]; // Merge object config such as alias, vars
            if (prev && isObject(prev)) {
                for (var k in curr) {
                    prev[k] = curr[k];
                }
            } else {
                // Concat array config such as map, preload
                if (isArray(prev)) {
                    curr = prev.concat(curr);
                }
                    // Make sure that `data.base` is an absolute path
                else if (key === "base") {
                    (curr.slice(-1) === "/") || (curr += "/");
                    curr = addBase(curr);
                }

                // Set config
                data[key] = curr;
            }
        }

        emit("config", configData);
        return seajs;
    };
})(this);