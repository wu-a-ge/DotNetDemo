//<%
/**
 * jsUnity Universal JavaScript Testing Framework v0.6
 * http://jsunity.com/
 *
 * Copyright (c) 2009 Ates Goral
 * Licensed under the MIT license.
 * http://www.opensource.org/licenses/mit-license.php
 */

jsUnity = (function () {
    function fmt(str) {
    	//取从第2个元素开始的后面所有的元素
        var a = Array.prototype.slice.call(arguments, 1);
        //表示每一个问号用一个数组中的元素来替换
        return str.replace(/\?/g, function () { return a.shift(); });
    }

    function hash(v) {
        if (v instanceof Object) {
            var arr = [];
            
            for (var p in v) {
                arr.push(p);
                arr.push(hash(v[p]));    
            }
            
            return arr.join("#");
        } else {
            return String(v);
        }
    }
    
    var defaultAssertions = {
        assertException: function (fn, message) {
            try {
                fn instanceof Function && fn();
            } catch (e) {
                return;
            }

            throw fmt("?: (?) does not raise an exception or not a function",
                message || "assertException", fn);
        },

        assertTrue: function (actual, message) {
            if (!actual) {
                throw fmt("?: (?) does not evaluate to true",
                    message || "assertTrue", actual);
            }
        },
        
        assertFalse: function (actual, message) {
            if (actual) {
                throw fmt("?: (?) does not evaluate to false",
                    message || "assertFalse", actual);
            }
        },
        
        assertIdentical: function (expected, actual, message) {
            if (expected !== actual) {
                throw fmt("?: (?) is not identical to (?)",
                    message || "assertIdentical", actual, expected);
            }
        },

        assertNotIdentical: function (expected, actual, message) {
            if (expected === actual) {
                throw fmt("?: (?) is identical to (?)",
                    message || "assertNotIdentical", actual, expected);
            }
        },

        assertEqual: function (expected, actual, message) {
            if (hash(expected) != hash(actual)) {
                throw fmt("?: (?) is not equal to (?)",
                    message || "assertEqual", actual, expected);
            }
        },
        
        assertNotEqual: function (expected, actual, message) {
            if (hash(expected) == hash(actual)) {
                throw fmt("?: (?) is equal to (?)",
                    message || "assertNotEqual", actual, expected);
            }
        },
        
        assertMatch: function (re, actual, message) {
            if (!re.test(actual)) {
                throw fmt("?: (?) does not match (?)",
                    message || "assertMatch", actual, re);
            }
        },
        
        assertNotMatch: function (re, actual, message) {
            if (re.test(actual)) {
                throw fmt("?: (?) matches (?)",
                    message || "assertNotMatch", actual, re);
            }
        },
        
        assertTypeOf: function (typ, actual, message) {
            if (typeof actual !== typ) {
                throw fmt("?: (?) is not of type (?)",
                    message || "assertTypeOf", actual, typ);
            }
        },

        assertNotTypeOf: function (typ, actual, message) {
            if (typeof actual === typ) {
                throw fmt("?: (?) is of type (?)",
                    message || "assertNotTypeOf", actual, typ);
            }
        },
        
        assertInstanceOf: function (cls, actual, message) {
            if (!(actual instanceof cls)) {
                throw fmt("?: (?) is not an instance of (?)",
                    message || "assertInstanceOf", actual, cls);
            }
        },

        assertNotInstanceOf: function (cls, actual, message) {
            if (actual instanceof cls) {
                throw fmt("?: (?) is an instance of (?)",
                    message || "assertNotInstanceOf", actual, cls);
            }
        },

        assertNull: function (actual, message) {
            if (actual !== null) {
                throw fmt("?: (?) is not null",
                    message || "assertNull", actual);
            }
        },
        
        assertNotNull: function (actual, message) {
            if (actual === null) {
                throw fmt("?: (?) is null",
                    message || "assertNotNull", actual);
            }
        },
        
        assertUndefined: function (actual, message) {
            if (actual !== undefined) {
                throw fmt("?: (?) is not undefined",
                    message || "assertUndefined", actual);
            }
        },
        
        assertNotUndefined: function (actual, message) {
            if (actual === undefined) {
                throw fmt("?: (?) is undefined",
                    message || "assertNotUndefined", actual);
            }
        },
        
        assertNaN: function (actual, message) {
            if (!isNaN(actual)) {
                throw fmt("?: (?) is not NaN",
                    message || "assertNaN", actual);
            }
        },
        
        assertNotNaN: function (actual, message) {
            if (isNaN(actual)) {
                throw fmt("?: (?) is NaN",
                    message || "assertNotNaN", actual);
            }
        },
        
        fail: function (message) {
            throw message || "fail";
        }
    };
    //返回显示信息，说明有多少个测试函数
    function plural(cnt, unit) {
        return cnt + " " + unit + (cnt == 1 ? "" : "s");
    }
    //传递的的地址就是函数的源代码，分离函数的名称和执行体，反回一个对象
    function splitFunction(fn) {
        var tokens =
            /^[\s\r\n]*function[\s\r\n]*([^\(\s\r\n]*?)[\s\r\n]*\([^\)\s\r\n]*\)[\s\r\n]*\{((?:[^}]*\}?)+)\}[\s\r\n]*$/
            .exec(fn);
        
        if (!tokens) {
            throw "Invalid function.";
        }
        //提取测试套件的名称和函数体
        return {
            name: tokens[1].length ? tokens[1] : undefined,
            body: tokens[2]
        };
    }
    //函数的名字，字符串形式，不是引用形式。用eval来测试这个给定的名字是不是函数，并且是否是外部函数
    //这里多了个&&逻辑符，会将传入的函数名判断是否存在，如果存在直接返回函数地址
    //否则抛弃异常，返回false
    var probeOutside = function () {
        try {
            return eval(
                [ "typeof ", " === \"function\" && ", "" ].join(arguments[0]));
        } catch (e) {
            return false;
        }
    };
	//用来从字符串中提取所有的测试函数
    function parseSuiteString(str) {
        var obj = {};
        //把测试函数套件中的测试函数字符串和转换函数体放在一起，测试函数可能不是外部函数，因此这里在将转换函数和测试函数放在一起可以得到是否存在相应的函数
        //如果存在返回函数地址，不存在返回fasle
        var probeInside = new Function(
            splitFunction(probeOutside).body + str);
			//只匹配单词字符
        var tokenRe = /(\w+)/g; // todo: wiser regex
        var tokens;
	    //循环处理一直查找所有测试函数的名字
        while ((tokens = tokenRe.exec(str))) {
            var token = tokens[1];//正则匹配出来的字符串可能为function,可能为测试函数的名字
            var fn;
            //测试函数名字，probeInside返回函数，如果不存在则返回false，probeOutside返回false或函数
            if (!obj[token]
                && (fn = probeInside(token))
                && fn != probeOutside(token)) {

                obj[token] = fn;
            }
        }

        return parseSuiteObject(obj);
    }
   //函数测试套件可以是匿名的或声明的函数
    function parseSuiteFunction(fn) {
        var fnParts = splitFunction(fn);
        var suite = parseSuiteString(fnParts.body);

        suite.suiteName = fnParts.name;

        return suite;
    }
    //要求数组测试套件的元素必须是字符串名字或名字地址引用，绝不能是匿名函数。
    function parseSuiteArray(tests) {
        var obj = {};

        for (var i = 0; i < tests.length; i++) {
            var item = tests[i];
            //用一个对象来保存函数。
            if (!obj[item]) {
                switch (typeof item) {
                case "function":
                    var fnParts = splitFunction(item);
                    obj[fnParts.name] = item;
                    break;
                case "string":
                    var fn;
                    //返回函数的引用
                    if (fn = probeOutside(item)) {
                        obj[item] = fn;
                    }
                }
            }
        }

        return parseSuiteObject(obj);
    }
    //只处理对象测试套件的属性为函数类型，返回一个测试套件对象TestSuite
    function parseSuiteObject(obj) {
        var suite = new jsUnity.TestSuite(obj.suiteName, obj);

        for (var name in obj) {
            if (obj.hasOwnProperty(name)) {
                var fn = obj[name];
								//测试函数名必须以test开头，或命名为setUp,tearDown
                if (typeof fn === "function") {
                    if (/^test/.test(name)) {
                        suite.tests.push({ name: name, fn: fn });
                    } else if (/^setUp|tearDown$/.test(name)) {
                        suite[name] = fn;
                    }
                }
            }
        }
        
        return suite;
    }

    return {
        TestSuite: function (suiteName, scope) {
            this.suiteName = suiteName;
            this.scope = scope;
            this.tests = [];
            this.setUp = undefined;
            this.tearDown = undefined;
        },

        TestResults: function () {
            this.suiteName = undefined;
            this.total = 0;
            this.passed = 0;
            this.failed = 0;
            this.duration = 0;
        },

        assertions: defaultAssertions,

        env: {
            defaultScope: this,//这个this就是window对象

            getDate: function () {
                return new Date();
            }
        },
        //转移断言的运行环境,默认转移到window对象
        attachAssertions: function (scope) {
            scope = scope || this.env.defaultScope;

            for (var fn in jsUnity.assertions) {
                scope[fn] = jsUnity.assertions[fn];
            }
        },
         //可以自定义
         /*
         jsUnity.log = function (s) {
    document.write("<div>" + s + "</div>");
};
         */
        log: function () {},
        /*
        jsUnity.error = function (s) {
    document.write("<div class=\"error\">" + s
        + "</div>");
};
        */
        //可以自定义
        error: function (s) { this.log("[ERROR] " + s); },

        compile: function (v) {
            if (v instanceof jsUnity.TestSuite) {
                return v;
            } else if (v instanceof Function) {
                return parseSuiteFunction(v);
            } else if (v instanceof Array) {
                return parseSuiteArray(v);
            } else if (v instanceof Object) {
                return parseSuiteObject(v);
            } else if (typeof v === "string") {
                return parseSuiteString(v);
            } else {
                throw "Argument must be a function, array, object, string or "
                    + "TestSuite instance.";
            }
        },

        run: function () {
            var results = new jsUnity.TestResults();

            var suiteNames = [];
            var start = jsUnity.env.getDate();

            for (var i = 0; i < arguments.length; i++) {
                try {
                    var suite = jsUnity.compile(arguments[i]);
                } catch (e) {
                    this.error("Invalid test suite: " + e);
                    return false;
                }

                var cnt = suite.tests.length;

                this.log("Running "
                    + (suite.suiteName || "unnamed test suite"));
                this.log(plural(cnt, "test") + " found");
    
                suiteNames.push(suite.suiteName);
                results.total += cnt;

                for (var j = 0; j < cnt; j++) {
                    var test = suite.tests[j];
    
                    try {
                        suite.setUp && suite.setUp();//每个测试函数开始前执行
                        test.fn.call(suite.scope);
                        suite.tearDown && suite.tearDown();//每个函数执行完了执行这个tearDown

                        results.passed++;

                        this.log("[PASSED] " + test.name);
                    } catch (e) {
                        suite.tearDown && suite.tearDown();

                        this.log("[FAILED] " + test.name + ": " + e);
                    }
                }
            }

            results.suiteName = suiteNames.join(",");
            results.failed = results.total - results.passed;
            results.duration = jsUnity.env.getDate() - start;

            this.log(plural(results.passed, "test") + " passed");
            this.log(plural(results.failed, "test") + " failed");
            this.log(plural(results.duration, "millisecond") + " elapsed");

            return results;
        }
    };
})();
//%>
