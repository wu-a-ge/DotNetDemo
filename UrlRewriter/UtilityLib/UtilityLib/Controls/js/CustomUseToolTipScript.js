(function($) {
    function _calculatePosition(field, promptElmt, options) {

        var promptTopPosition, promptleftPosition, marginTopSize;
        var fieldWidth = field.width();
        var promptHeight = promptElmt.height();

        var overflow = options.isOverflown;
        if (overflow) {
            // is the form contained in an overflown container?
            promptTopPosition = promptleftPosition = 0;
            // compensation for the arrow
            marginTopSize = -promptHeight;
        } else {
            var offset = field.offset();
            promptTopPosition = offset.top;
            promptleftPosition = offset.left;
            marginTopSize = 0;
        }

        switch (options.promptPosition) {

            default:
            case "topRight":
                if (overflow)
                // Is the form contained in an overflown container?
                    promptleftPosition += fieldWidth - 30;
                else {
                    promptleftPosition += fieldWidth - 30;
                    promptTopPosition += -promptHeight;
                }
                break;
            case "topLeft":
                promptTopPosition += -promptHeight - 10;
                break;
            case "centerRight":
                promptleftPosition += fieldWidth + 13;
                break;
            case "bottomLeft":
                promptTopPosition = promptTopPosition + field.height() + 15;
                break;
            case "bottomRight":
                promptleftPosition += fieldWidth - 30;
                promptTopPosition += field.height() + 5;
        }

        return {
            "callerTopPosition": promptTopPosition + "px",
            "callerleftPosition": promptleftPosition + "px",
            "marginTopSize": marginTopSize + "px"
        };
    }
    function _buildPrompt(field, promptText, type, ajaxed, options) {

        // create the prompt
        var prompt = $('<div>');
        prompt.addClass(field.attr("id").replace(":", "_") + "formError");
        // add a class name to identify the parent form of the prompt
        if (field.is(":input")) prompt.addClass("parentForm" + field.parents('form').attr("id").replace(":", "_"));
        prompt.addClass("formError");

        switch (type) {
            case "pass":
                prompt.addClass("greenPopup");
                break;
            case "load":
                prompt.addClass("blackPopup");
        }
        if (ajaxed)
            prompt.addClass("ajaxed");

        // create the prompt content
        var promptContent = $('<div>').addClass("formErrorContent").html(promptText).appendTo(prompt);
        // create the css arrow pointing at the field
        // note that there is no triangle on max-checkbox and radio
        if (options.showArrow) {
            var arrow = $('<div>').addClass("formErrorArrow");

            switch (options.promptPosition) {
                case "bottomLeft":
                case "bottomRight":
                    prompt.find(".formErrorContent").before(arrow);
                    arrow.addClass("formErrorArrowBottom").html('<div class="line1"><!-- --></div><div class="line2"><!-- --></div><div class="line3"><!-- --></div><div class="line4"><!-- --></div><div class="line5"><!-- --></div><div class="line6"><!-- --></div><div class="line7"><!-- --></div><div class="line8"><!-- --></div><div class="line9"><!-- --></div><div class="line10"><!-- --></div>');
                    break;
                case "topLeft":
                case "topRight":
                    arrow.html('<div class="line10"><!-- --></div><div class="line9"><!-- --></div><div class="line8"><!-- --></div><div class="line7"><!-- --></div><div class="line6"><!-- --></div><div class="line5"><!-- --></div><div class="line4"><!-- --></div><div class="line3"><!-- --></div><div class="line2"><!-- --></div><div class="line1"><!-- --></div>');
                    prompt.append(arrow);
                    break;
            }
        }

        //Cedric: Needed if a container is in position:relative
        // insert prompt in the form or in the overflown container?
        if (options.isOverflown)
            field.before(prompt);
        else
            $("body").append(prompt);

        var pos = _calculatePosition(field, prompt, options);
        prompt.css({
            "top": pos.callerTopPosition,
            "left": pos.callerleftPosition,
            "marginTop": pos.marginTopSize,
            "opacity": 0
        });

        return prompt.animate({
            "opacity": 0.87
        });

    }
    function _updatePrompt(field, prompt, promptText, type, ajaxed, options) {

        if (prompt) {
            if (type == "pass")
                prompt.addClass("greenPopup");
            else
                prompt.removeClass("greenPopup");

            if (type == "load")
                prompt.addClass("blackPopup");
            else
                prompt.removeClass("blackPopup");

            if (ajaxed)
                prompt.addClass("ajaxed");
            else
                prompt.removeClass("ajaxed");

            prompt.find(".formErrorContent").html(promptText);

            var pos = _calculatePosition(field, prompt, options);
            prompt.animate({
                "top": pos.callerTopPosition,
                "marginTop": pos.marginTopSize
            });
        }
    }


    //如果有，返回错误提示DIV对象（Jqobject）
    function _getPrompt(field) {
        //用控件ID+formError查找控件的错误提示文本DIV，如：phoneformError
        var className = "." + field.attr("id").replace(":", "_") + "formError";
        var match = $(className)[0];
        if (match)
            return $(match);
    }

    function _showPrompt(field, promptText, type, ajaxed, options) {
        var prompt = _getPrompt(field);
        if (prompt)
            _updatePrompt(field, prompt, promptText, type, ajaxed, options);
        else
            _buildPrompt(field, promptText, type, ajaxed, options);
    }
    function _saveOptions(form, options) {

        var userOptions = $.extend({
            // Automatically scroll viewport to the first error
            isScroll: true,
            // Opening box position, possible locations are: topLeft,
            // topRight, bottomLeft, centerRight, bottomRight
            promptPosition: "topRight",
            // Used when the form is displayed within a scrolling DIV
            isOverflown: false,
            overflownDIV: "",
            // set to true, when the prompt arrow needs to be displayed
            showArrow: true

        }, options);
        form.data('jqv', userOptions);
        return userOptions;
    }
    //显示当前字段的提示信息,作为jQuery插件
    $.fn.showPrompt = function(promptText, type, promptPosition, showArrow, isScroll) {

        var options = $(this).data('jqv');
        // No option, take default one
        if (!options) options = _saveOptions(this, options);
        if (promptPosition)
            options.promptPosition = promptPosition;
        options.showArrow = showArrow === true;
        options.isScroll = isScroll === true;
        _showPrompt(this, promptText, type, false, options);
    };
    //初始化为错误提示信息绑定click事件
    function init() {
        //为所有的提示弹出层用live方法来绑定click事件（现在是绑定到DOM根节点）
        // bind all formError elements to close on click
        $(".formError").live("click", function() {
            $(this).fadeOut(150, function() {

                // remove prompt once invisible
                $(this).remove();
            });
        });

    }
    init();
})(jQuery);


function ValidatorUpdateDisplay(val) {
//兼容使用原生验证控件没有提示信息属性
    if (val.useToolTip) {
        if ((!!val.useToolTip == true) && val.isvalid == false) {
            $("#" + val.controltovalidate).showPrompt(val.errormessage, "", val.promptPosition, !!val.showArrow, !!val.isScroll);
            return;
        }
    }
    if (typeof (val.display) == "string") {
        if (val.display == "None") {
            return;
        }
        if (val.display == "Dynamic") {
            val.style.display = val.isvalid ? "none" : "inline";
            return;
        }
    }
    if ((navigator.userAgent.indexOf("Mac") > -1) &&
        (navigator.userAgent.indexOf("MSIE") > -1)) {
        val.style.display = "inline";
    }
    val.style.visibility = val.isvalid ? "hidden" : "visible";
}