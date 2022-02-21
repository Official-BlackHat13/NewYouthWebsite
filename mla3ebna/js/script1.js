

// ******************************
//
// 		Google Analytic
//
// ******************************

var $ = jQuery.noConflict();
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

ga('create', 'UA-52876960-1', 'auto');
ga('send', 'pageview');


// ******************************
//
// 		megamenu
//
// ******************************

$(document).ready(function () { $(".megamenu").megamenu(); });
$.fn.megamenu = function (e) { function r() { $(".megamenu").find("li, a").unbind(); if (window.innerWidth <= 992) { o(); s(); if (n == 0) { $(".megamenu > li:not(.showhide)").hide(0) } } else { u(); i() } } function i() { $(".megamenu li").bind("mouseover", function () { $(this).children(".dropdown, .megapanel").stop().fadeIn(t.interval) }).bind("mouseleave", function () { $(this).children(".dropdown, .megapanel").stop().fadeOut(t.interval) }) } function s() { $(".megamenu > li > a").bind("click", function (e) { if ($(this).siblings(".dropdown, .megapanel").css("display") == "none") { $(this).siblings(".dropdown, .megapanel").slideDown(t.interval); $(this).siblings(".dropdown").find("ul").slideDown(t.interval); n = 1 } else { $(this).siblings(".dropdown, .megapanel").slideUp(t.interval) } }) } function o() { $(".megamenu > li.showhide").show(0); $(".megamenu > li.showhide").bind("click", function () { if ($(".megamenu > li").is(":hidden")) { $(".megamenu > li").slideDown(253) } else { $(".megamenu > li:not(.showhide)").slideUp(253); $(".megamenu > li.showhide").show(0) } }) } function u() { $(".megamenu > li").show(0); $(".megamenu > li.showhide").hide(0) } var t = { interval: 250 }; var n = 0; $(".megamenu").prepend("<li class='showhide'><span class='icon1'></span><span class='icon2'></span><span class='icon3'></span></li>"); r(); $(window).resize(function () { r() }) }


// ******************************
//
// 		Counter
//
// ******************************

eval(function (p, a, c, k, e, d) { e = function (c) { return c }; if (!''.replace(/^/, String)) { while (c--) { d[c] = k[c] || c } k = [function (e) { return d[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) { if (k[c]) { p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]) } } return p }('(6($){$.58.5=6(2){3 31={5:10,13:33,9:30};3 2=$.54(31,2);20 14.42(6(){3 4=$(14);12(2.13){12(2.9==30||2.9.11==0){3 32=\'<27 41 = "66:\'+4[0].49+\'48;47-50:51"></27>\';4.53(32)}}4.7(4.7().28(0,2.5));18(14,2.5,2.9,2.13);4.25("46",6(19){3 23=19.23?19.23:19.44;3 29=36 35(8,37,38,39,40);55(3 21=0;21<29.11;21++){12(23==29[21])20 33}20 18(14,2.5,2.9,2.13)});4.25("67",6(19){18(14,2.5,2.9,2.13)});4.25(\'62 57 56\',6(){3 24=$(14);59(6(){24.7(24.7().28(0,2.5));18(24,2.5,2.9,2.13)},63)})})}})(68);6 18(16,22,15,34){3 11=$(16).7().11;3 17=22-11;12(17<0){$(16).7($(16).7().28(0,22));17=0}12(34){12(15==30||15.11==0){15=$(16).52()}3 26=15[0].45.65();12(26=="61"||26=="27"){15.64(17+" 69"+(17>1?"60":"")+" 43.")}}20 11<=22-1}', 10, 70, '||options|var|textBox|MaxLength|function|val||CharacterCountControl||length|if|DisplayCharacterCount|this|control|t|characters|SetCharacterCount|e|return|i|maxLength|keyCode|textarea|bind|tagName|div|substring|codes|null|defaults|counter|true|isVisible|Array|new|||||style|each|المتبقية|which|nodeName|keypress|text|px|offsetWidth|align|right|next|after|extend|for|blur|drop|fn|setTimeout| |span|paste|100|html|toLowerCase|width|keyup|jQuery|الأحرف'.split('|'), 0, {}))

$(function () {

    $("[id*=txtSuggestions]").MaxLength(
    {
        MaxLength: 1000,

        CharacterCountControl: $('#counter')
    });
});


//$(function () {

//    $("[id*=txtpblmAddressed]").MaxLength(
//    {
//        MaxLength: 5000,

//        CharacterCountControl: $('#counterProblem')
//    });
//});

//$(function () {

//    $("[id*=txtslntnbyProject]").MaxLength(
//    {
//        MaxLength: 5000,
//        CharacterCountControl: $('#counterProjcet')
//    });
//});
//$(function () {

//    $("[id*=txtimplementationofProject]").MaxLength(
//    {
//        MaxLength: 5000,

//        CharacterCountControl: $('#counterimplementationofProject')
//    });
//});

$(function () {

    $("[id*=txtProjectinDetail]").MaxLength(
    {
        MaxLength: 5000,

        CharacterCountControl: $('#counterProjectinDetail')
    });
});


//$(function () {

//    $("[id*=txtImpactofProject]").MaxLength(
//    {
//        MaxLength: 5000,

//        CharacterCountControl: $('#counterImpactofProject')
//    });
//});


$(function () {

    $("[id*=txtsummery]").MaxLength(
    {
        MaxLength: 1000,

        CharacterCountControl: $('#counter')
    });
});

$(function () {

    $("[id*=txtachievmnts]").MaxLength(
    {
        MaxLength: 1000,
        CharacterCountControl: $('#counter1')
    });
});
$(function () {

    $("[id*=txtIdeas]").MaxLength(
    {
        MaxLength: 1000,

        CharacterCountControl: $('#count')
    });
});

// ******************************
//
// 		cannot copy
//
// ******************************
$(document).ready(function () {
    $("[id*=txtSuggestions]").bind('paste', function (e) {
        e.preventDefault();
        alert("You cannot paste text into this textbox!");
    });
});


// ******************************
//
// 		Navigation Menu Slider
//
// ******************************
var $ = jQuery.noConflict();
$(document).ready(function () {

    //Navigation Menu Slider
    $('#nav-expander').on('click', function (e) {
        e.preventDefault();
        $('body').toggleClass('nav-expanded');
    });
    $('#nav-close').on('click', function (e) {
        e.preventDefault();
        $('body').removeClass('nav-expanded');
    });
});




// ******************************
//
// 		EASY NEWS TICKER
//
// ******************************
var $ = jQuery.noConflict();
$(function () {
    $('.demo5').easyTicker({
    });
});

; (function ($, window, document, undefined) {

    var name = "easyTicker",
                defaults = {
                direction: 'up',
                easing: 'swing',
                speed: 'slow',
                interval: 2000,
                height: '160',
                visible: 6,
                mousePause: 1,
                direction: 'up',
                visible: 6,
                interval: 2500,
            };

    // Constructor
    function EasyTicker(el, options) {

        var s = this;

        s.opts = $.extend({}, defaults, options);
        s.elem = $(el);
        s.targ = $(el).children(':first-child');
        s.timer = 0;
        s.mHover = 0;
        s.winFocus = 1;

        init();
        start();

        $([window, document]).off('focus.jqet').on('focus.jqet', function () {
            s.winFocus = 1;
        }).off('blur.jqet').on('blur.jqet', function () {
            s.winFocus = 0;
        });

        if (s.opts.mousePause == 1) {
            s.elem.mouseenter(function () {
                s.timerTemp = s.timer;
                stop();
            }).mouseleave(function () {
                if (s.timerTemp !== 0)
                    start();
            });
        }

        $(s.opts.controls.up).on('click', function (e) {
            e.preventDefault();
            moveDir('up');
        });

        $(s.opts.controls.down).on('click', function (e) {
            e.preventDefault();
            moveDir('down');
        });

        $(s.opts.controls.toggle).on('click', function (e) {
            e.preventDefault();
            if (s.timer == 0) start();
            else stop();
        });

        function init() {

            s.elem.children().css('margin', 0).children().css('margin', 0);

            s.elem.css({
                position: 'relative',
                height: s.opts.height,
                overflow: 'hidden'
            });

            s.targ.css({
                'position': 'absolute',
                'margin': 0
            });

            setInterval(function () {
                adjHeight();
            }, 100);

        } // Init Method

        function start() {
            s.timer = setInterval(function () {
                if (s.winFocus == 1) {
                    move(s.opts.direction);
                }
            }, s.opts.interval);

            $(s.opts.controls.toggle).addClass('et-run').html(s.opts.controls.stopText);

        } // Start method


        function stop() {
            clearInterval(s.timer);
            s.timer = 0;
            $(s.opts.controls.toggle).removeClass('et-run').html(s.opts.controls.playText);
        }// Stop


        function move(dir) {
            var sel, eq, appType;

            if (!s.elem.is(':visible')) return;

            if (dir == 'up') {
                sel = ':first-child';
                eq = '-=';
                appType = 'appendTo';
            } else {
                sel = ':last-child';
                eq = '+=';
                appType = 'prependTo';
            }

            var selChild = s.targ.children(sel);
            var height = selChild.outerHeight();

            s.targ.stop(true, true).animate({
                'top': eq + height + "px"
            }, s.opts.speed, s.opts.easing, function () {

                selChild.hide()[appType](s.targ).fadeIn();
                s.targ.css('top', 0);

                adjHeight();

            });
        }// Move

        function moveDir(dir) {
            stop();
            if (dir == 'up') move('up'); else move('down');
            // start();
        }

        function fullHeight() {
            var height = 0;
            var tempDisp = s.elem.css('display'); // Get the current el display value

            s.elem.css('display', 'block');

            s.targ.children().each(function () {
                height += $(this).outerHeight();
            });

            s.elem.css({
                'display': tempDisp,
                'height': height
            });
        }

        function visHeight(anim) {
            var wrapHeight = 0;
            s.targ.children(':lt(' + s.opts.visible + ')').each(function () {
                wrapHeight += $(this).outerHeight();
            });

            if (anim == 1) {
                s.elem.stop(true, true).animate({ height: wrapHeight }, s.opts.speed);
            } else {
                s.elem.css('height', wrapHeight);
            }
        }

        function adjHeight() {
            if (s.opts.height == 'auto' && s.opts.visible != 0) {
                anim = arguments.callee.caller.name == 'init' ? 0 : 1;
                visHeight(anim);
            } else if (s.opts.height == 'auto') {
                fullHeight();
            }
        }

        return {
            up: function () { moveDir('up'); },
            down: function () { moveDir('down'); },
            start: start,
            stop: stop,
            options: s.opts
        };

    }

    // Attach the object to the DOM
    $.fn[name] = function (options) {
        return this.each(function () {
            if (!$.data(this, name)) {
                $.data(this, name, new EasyTicker(this, options));
            }
        });
    };

})(jQuery, window, document);





//// ******************************
//// marquee	
//// ******************************

//var $ = jQuery.noConflict();
//$(document).ready(function () {
//    $('.simple-marquee-container').SimpleMarquee();

//});


// ******************************
//
// 		Select Box
//
// ******************************


(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module unless amdModuleId is set
        define(["jquery"], function (a0) {
            return (factory(a0));
        });
    } else if (typeof exports === 'object') {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(require("jquery"));
    } else {
        factory(jQuery);
    }
}(this, function (jQuery) {

    (function ($) {
        'use strict';

        //<editor-fold desc="Shims">
        if (!String.prototype.includes) {
            (function () {
                'use strict'; // needed to support `apply`/`call` with `undefined`/`null`
                var toString = {}.toString;
                var defineProperty = (function () {
                    // IE 8 only supports `Object.defineProperty` on DOM elements
                    try {
                        var object = {};
                        var $defineProperty = Object.defineProperty;
                        var result = $defineProperty(object, object, object) && $defineProperty;
                    } catch (error) {
                    }
                    return result;
                }());
                var indexOf = ''.indexOf;
                var includes = function (search) {
                    if (this == null) {
                        throw new TypeError();
                    }
                    var string = String(this);
                    if (search && toString.call(search) == '[object RegExp]') {
                        throw new TypeError();
                    }
                    var stringLength = string.length;
                    var searchString = String(search);
                    var searchLength = searchString.length;
                    var position = arguments.length > 1 ? arguments[1] : undefined;
                    // `ToInteger`
                    var pos = position ? Number(position) : 0;
                    if (pos != pos) { // better `isNaN`
                        pos = 0;
                    }
                    var start = Math.min(Math.max(pos, 0), stringLength);
                    // Avoid the `indexOf` call if no match is possible
                    if (searchLength + start > stringLength) {
                        return false;
                    }
                    return indexOf.call(string, searchString, pos) != -1;
                };
                if (defineProperty) {
                    defineProperty(String.prototype, 'includes', {
                        'value': includes,
                        'configurable': true,
                        'writable': true
                    });
                } else {
                    String.prototype.includes = includes;
                }
            }());
        }

        if (!String.prototype.startsWith) {
            (function () {
                'use strict'; // needed to support `apply`/`call` with `undefined`/`null`
                var defineProperty = (function () {
                    // IE 8 only supports `Object.defineProperty` on DOM elements
                    try {
                        var object = {};
                        var $defineProperty = Object.defineProperty;
                        var result = $defineProperty(object, object, object) && $defineProperty;
                    } catch (error) {
                    }
                    return result;
                }());
                var toString = {}.toString;
                var startsWith = function (search) {
                    if (this == null) {
                        throw new TypeError();
                    }
                    var string = String(this);
                    if (search && toString.call(search) == '[object RegExp]') {
                        throw new TypeError();
                    }
                    var stringLength = string.length;
                    var searchString = String(search);
                    var searchLength = searchString.length;
                    var position = arguments.length > 1 ? arguments[1] : undefined;
                    // `ToInteger`
                    var pos = position ? Number(position) : 0;
                    if (pos != pos) { // better `isNaN`
                        pos = 0;
                    }
                    var start = Math.min(Math.max(pos, 0), stringLength);
                    // Avoid the `indexOf` call if no match is possible
                    if (searchLength + start > stringLength) {
                        return false;
                    }
                    var index = -1;
                    while (++index < searchLength) {
                        if (string.charCodeAt(start + index) != searchString.charCodeAt(index)) {
                            return false;
                        }
                    }
                    return true;
                };
                if (defineProperty) {
                    defineProperty(String.prototype, 'startsWith', {
                        'value': startsWith,
                        'configurable': true,
                        'writable': true
                    });
                } else {
                    String.prototype.startsWith = startsWith;
                }
            }());
        }

        if (!Object.keys) {
            Object.keys = function (
              o, // object
              k, // key
              r  // result array
              ) {
                // initialize object and result
                r = [];
                // iterate over object keys
                for (k in o)
                    // fill result array with non-prototypical keys
                    r.hasOwnProperty.call(o, k) && r.push(k);
                // return result
                return r;
            };
        }

        $.fn.triggerNative = function (eventName) {
            var el = this[0],
                event;

            if (el.dispatchEvent) {
                if (typeof Event === 'function') {
                    // For modern browsers
                    event = new Event(eventName, {
                        bubbles: true
                    });
                } else {
                    // For IE since it doesn't support Event constructor
                    event = document.createEvent('Event');
                    event.initEvent(eventName, true, false);
                }

                el.dispatchEvent(event);
            } else {
                if (el.fireEvent) {
                    event = document.createEventObject();
                    event.eventType = eventName;
                    el.fireEvent('on' + eventName, event);
                }

                this.trigger(eventName);
            }
        };
        //</editor-fold>

        // Case insensitive contains search
        $.expr[':'].icontains = function (obj, index, meta) {
            var $obj = $(obj);
            var haystack = ($obj.data('tokens') || $obj.text()).toUpperCase();
            return haystack.includes(meta[3].toUpperCase());
        };

        // Case insensitive begins search
        $.expr[':'].ibegins = function (obj, index, meta) {
            var $obj = $(obj);
            var haystack = ($obj.data('tokens') || $obj.text()).toUpperCase();
            return haystack.startsWith(meta[3].toUpperCase());
        };

        // Case and accent insensitive contains search
        $.expr[':'].aicontains = function (obj, index, meta) {
            var $obj = $(obj);
            var haystack = ($obj.data('tokens') || $obj.data('normalizedText') || $obj.text()).toUpperCase();
            return haystack.includes(meta[3].toUpperCase());
        };

        // Case and accent insensitive begins search
        $.expr[':'].aibegins = function (obj, index, meta) {
            var $obj = $(obj);
            var haystack = ($obj.data('tokens') || $obj.data('normalizedText') || $obj.text()).toUpperCase();
            return haystack.startsWith(meta[3].toUpperCase());
        };

        /**
         * Remove all diatrics from the given text.
         * @access private
         * @param {String} text
         * @returns {String}
         */
        function normalizeToBase(text) {
            var rExps = [
              { re: /[\xC0-\xC6]/g, ch: "A" },
              { re: /[\xE0-\xE6]/g, ch: "a" },
              { re: /[\xC8-\xCB]/g, ch: "E" },
              { re: /[\xE8-\xEB]/g, ch: "e" },
              { re: /[\xCC-\xCF]/g, ch: "I" },
              { re: /[\xEC-\xEF]/g, ch: "i" },
              { re: /[\xD2-\xD6]/g, ch: "O" },
              { re: /[\xF2-\xF6]/g, ch: "o" },
              { re: /[\xD9-\xDC]/g, ch: "U" },
              { re: /[\xF9-\xFC]/g, ch: "u" },
              { re: /[\xC7-\xE7]/g, ch: "c" },
              { re: /[\xD1]/g, ch: "N" },
              { re: /[\xF1]/g, ch: "n" }
            ];
            $.each(rExps, function () {
                text = text.replace(this.re, this.ch);
            });
            return text;
        }


        function htmlEscape(html) {
            var escapeMap = {
                '&': '&amp;',
                '<': '&lt;',
                '>': '&gt;',
                '"': '&quot;',
                "'": '&#x27;',
                '`': '&#x60;'
            };
            var source = '(?:' + Object.keys(escapeMap).join('|') + ')',
                testRegexp = new RegExp(source),
                replaceRegexp = new RegExp(source, 'g'),
                string = html == null ? '' : '' + html;
            return testRegexp.test(string) ? string.replace(replaceRegexp, function (match) {
                return escapeMap[match];
            }) : string;
        }

        var Selectpicker = function (element, options, e) {
            if (e) {
                e.stopPropagation();
                e.preventDefault();
            }

            this.$element = $(element);
            this.$newElement = null;
            this.$button = null;
            this.$menu = null;
            this.$lis = null;
            this.options = options;

            // If we have no title yet, try to pull it from the html title attribute (jQuery doesnt' pick it up as it's not a
            // data-attribute)
            if (this.options.title === null) {
                this.options.title = this.$element.attr('title');
            }

            //Expose public methods
            this.val = Selectpicker.prototype.val;
            this.render = Selectpicker.prototype.render;
            this.refresh = Selectpicker.prototype.refresh;
            this.setStyle = Selectpicker.prototype.setStyle;
            this.selectAll = Selectpicker.prototype.selectAll;
            this.deselectAll = Selectpicker.prototype.deselectAll;
            this.destroy = Selectpicker.prototype.destroy;
            this.remove = Selectpicker.prototype.remove;
            this.show = Selectpicker.prototype.show;
            this.hide = Selectpicker.prototype.hide;

            this.init();
        };

        Selectpicker.VERSION = '1.10.0';

        // part of this is duplicated in i18n/defaults-en_US.js. Make sure to update both.
        Selectpicker.DEFAULTS = {
            noneSelectedText: 'Nothing selected',
            noneResultsText: 'No results matched {0}',
            countSelectedText: function (numSelected, numTotal) {
                return (numSelected == 1) ? "{0} item selected" : "{0} items selected";
            },
            maxOptionsText: function (numAll, numGroup) {
                return [
                  (numAll == 1) ? 'Limit reached ({n} item max)' : 'Limit reached ({n} items max)',
                  (numGroup == 1) ? 'Group limit reached ({n} item max)' : 'Group limit reached ({n} items max)'
                ];
            },
            selectAllText: 'Select All',
            deselectAllText: 'Deselect All',
            doneButton: false,
            doneButtonText: 'Close',
            multipleSeparator: ', ',
            styleBase: 'btn',
            style: 'btn-info',
            size: 'auto',
            title: null,
            selectedTextFormat: 'values',
            width: false,
            container: false,
            hideDisabled: false,
            showSubtext: false,
            showIcon: true,
            showContent: true,
            dropupAuto: true,
            header: false,
            liveSearch: false,
            liveSearchPlaceholder: null,
            liveSearchNormalize: false,
            liveSearchStyle: 'contains',
            actionsBox: false,
            iconBase: 'glyphicon',
            tickIcon: 'glyphicon-ok',
            showTick: false,
            template: {
                caret: '<span class="caret"></span>'
            },
            maxOptions: false,
            mobile: false,
            selectOnTab: false,
            dropdownAlignRight: false
        };

        Selectpicker.prototype = {

            constructor: Selectpicker,

            init: function () {
                var that = this,
                    id = this.$element.attr('id');

                this.$element.addClass('bs-select-hidden');

                // store originalIndex (key) and newIndex (value) in this.liObj for fast accessibility
                // allows us to do this.$lis.eq(that.liObj[index]) instead of this.$lis.filter('[data-original-index="' + index + '"]')
                this.liObj = {};
                this.multiple = this.$element.prop('multiple');
                this.autofocus = this.$element.prop('autofocus');
                this.$newElement = this.createView();
                this.$element
                  .after(this.$newElement)
                  .appendTo(this.$newElement);
                this.$button = this.$newElement.children('button');
                this.$menu = this.$newElement.children('.dropdown-menu');
                this.$menuInner = this.$menu.children('.inner');
                this.$searchbox = this.$menu.find('input');

                this.$element.removeClass('bs-select-hidden');

                if (this.options.dropdownAlignRight)
                    this.$menu.addClass('dropdown-menu-right');

                if (typeof id !== 'undefined') {
                    this.$button.attr('data-id', id);
                    $('label[for="' + id + '"]').click(function (e) {
                        e.preventDefault();
                        that.$button.focus();
                    });
                }

                this.checkDisabled();
                this.clickListener();
                if (this.options.liveSearch) this.liveSearchListener();
                this.render();
                this.setStyle();
                this.setWidth();
                if (this.options.container) this.selectPosition();
                this.$menu.data('this', this);
                this.$newElement.data('this', this);
                if (this.options.mobile) this.mobile();

                this.$newElement.on({
                    'hide.bs.dropdown': function (e) {
                        that.$element.trigger('hide.bs.select', e);
                    },
                    'hidden.bs.dropdown': function (e) {
                        that.$element.trigger('hidden.bs.select', e);
                    },
                    'show.bs.dropdown': function (e) {
                        that.$element.trigger('show.bs.select', e);
                    },
                    'shown.bs.dropdown': function (e) {
                        that.$element.trigger('shown.bs.select', e);
                    }
                });

                if (that.$element[0].hasAttribute('required')) {
                    this.$element.on('invalid', function () {
                        that.$button
                          .addClass('bs-invalid')
                          .focus();

                        that.$element.on({
                            'focus.bs.select': function () {
                                that.$button.focus();
                                that.$element.off('focus.bs.select');
                            },
                            'shown.bs.select': function () {
                                that.$element
                                  .val(that.$element.val()) // set the value to hide the validation message in Chrome when menu is opened
                                  .off('shown.bs.select');
                            },
                            'rendered.bs.select': function () {
                                // if select is no longer invalid, remove the bs-invalid class
                                if (this.validity.valid) that.$button.removeClass('bs-invalid');
                                that.$element.off('rendered.bs.select');
                            }
                        });

                    });
                }

                setTimeout(function () {
                    that.$element.trigger('loaded.bs.select');
                });
            },

            createDropdown: function () {
                // Options
                // If we are multiple or showTick option is set, then add the show-tick class
                var showTick = (this.multiple || this.options.showTick) ? ' show-tick' : '',
                    inputGroup = this.$element.parent().hasClass('input-group') ? ' input-group-btn' : '',
                    autofocus = this.autofocus ? ' autofocus' : '';
                // Elements
                var header = this.options.header ? '<div class="popover-title"><button type="button" class="close" aria-hidden="true">&times;</button>' + this.options.header + '</div>' : '';
                var searchbox = this.options.liveSearch ?
                '<div class="bs-searchbox">' +
                '<input type="text" class="form-control" autocomplete="off"' +
                (null === this.options.liveSearchPlaceholder ? '' : ' placeholder="' + htmlEscape(this.options.liveSearchPlaceholder) + '"') + '>' +
                '</div>'
                    : '';
                var actionsbox = this.multiple && this.options.actionsBox ?
                '<div class="bs-actionsbox">' +
                '<div class="btn-group btn-group-sm btn-block">' +
                '<button type="button" class="actions-btn bs-select-all btn btn-default">' +
                this.options.selectAllText +
                '</button>' +
                '<button type="button" class="actions-btn bs-deselect-all btn btn-default">' +
                this.options.deselectAllText +
                '</button>' +
                '</div>' +
                '</div>'
                    : '';
                var donebutton = this.multiple && this.options.doneButton ?
                '<div class="bs-donebutton">' +
                '<div class="btn-group btn-block">' +
                '<button type="button" class="btn btn-sm btn-default">' +
                this.options.doneButtonText +
                '</button>' +
                '</div>' +
                '</div>'
                    : '';
                var drop =
                    '<div class="btn-group bootstrap-select' + showTick + inputGroup + '">' +
                    '<button type="button" class="' + this.options.styleBase + ' dropdown-toggle" data-toggle="dropdown"' + autofocus + '>' +
                    '<span class="filter-option pull-left"></span>&nbsp;' +
                    '<span class="bs-caret">' +
                    this.options.template.caret +
                    '</span>' +
                    '</button>' +
                    '<div class="dropdown-menu open">' +
                    header +
                    searchbox +
                    actionsbox +
                    '<ul class="dropdown-menu inner" role="menu">' +
                    '</ul>' +
                    donebutton +
                    '</div>' +
                    '</div>';

                return $(drop);
            },

            createView: function () {
                var $drop = this.createDropdown(),
                    li = this.createLi();

                $drop.find('ul')[0].innerHTML = li;
                return $drop;
            },

            reloadLi: function () {
                //Remove all children.
                this.destroyLi();
                //Re build
                var li = this.createLi();
                this.$menuInner[0].innerHTML = li;
            },

            destroyLi: function () {
                this.$menu.find('li').remove();
            },

            createLi: function () {
                var that = this,
                    _li = [],
                    optID = 0,
                    titleOption = document.createElement('option'),
                    liIndex = -1; // increment liIndex whenever a new <li> element is created to ensure liObj is correct

                // Helper functions
                /**
                 * @param content
                 * @param [index]
                 * @param [classes]
                 * @param [optgroup]
                 * @returns {string}
                 */
                var generateLI = function (content, index, classes, optgroup) {
                    return '<li' +
                        ((typeof classes !== 'undefined' & '' !== classes) ? ' class="' + classes + '"' : '') +
                        ((typeof index !== 'undefined' & null !== index) ? ' data-original-index="' + index + '"' : '') +
                        ((typeof optgroup !== 'undefined' & null !== optgroup) ? 'data-optgroup="' + optgroup + '"' : '') +
                        '>' + content + '</li>';
                };

                /**
                 * @param text
                 * @param [classes]
                 * @param [inline]
                 * @param [tokens]
                 * @returns {string}
                 */
                var generateA = function (text, classes, inline, tokens) {
                    return '<a tabindex="0"' +
                        (typeof classes !== 'undefined' ? ' class="' + classes + '"' : '') +
                        (typeof inline !== 'undefined' ? ' style="' + inline + '"' : '') +
                        (that.options.liveSearchNormalize ? ' data-normalized-text="' + normalizeToBase(htmlEscape(text)) + '"' : '') +
                        (typeof tokens !== 'undefined' || tokens !== null ? ' data-tokens="' + tokens + '"' : '') +
                        '>' + text +
                        '<span class="' + that.options.iconBase + ' ' + that.options.tickIcon + ' check-mark"></span>' +
                        '</a>';
                };

                if (this.options.title && !this.multiple) {
                    // this option doesn't create a new <li> element, but does add a new option, so liIndex is decreased
                    // since liObj is recalculated on every refresh, liIndex needs to be decreased even if the titleOption is already appended
                    liIndex--;

                    if (!this.$element.find('.bs-title-option').length) {
                        // Use native JS to prepend option (faster)
                        var element = this.$element[0];
                        titleOption.className = 'bs-title-option';
                        titleOption.appendChild(document.createTextNode(this.options.title));
                        titleOption.value = '';
                        element.insertBefore(titleOption, element.firstChild);
                        // Check if selected attribute is already set on an option. If not, select the titleOption option.
                        if ($(element.options[element.selectedIndex]).attr('selected') === undefined) titleOption.selected = true;
                    }
                }

                this.$element.find('option').each(function (index) {
                    var $this = $(this);

                    liIndex++;

                    if ($this.hasClass('bs-title-option')) return;

                    // Get the class and text for the option
                    var optionClass = this.className || '',
                        inline = this.style.cssText,
                        text = $this.data('content') ? $this.data('content') : $this.html(),
                        tokens = $this.data('tokens') ? $this.data('tokens') : null,
                        subtext = typeof $this.data('subtext') !== 'undefined' ? '<small class="text-muted">' + $this.data('subtext') + '</small>' : '',
                        icon = typeof $this.data('icon') !== 'undefined' ? '<span class="' + that.options.iconBase + ' ' + $this.data('icon') + '"></span> ' : '',
                        isOptgroup = this.parentNode.tagName === 'OPTGROUP',
                        isDisabled = this.disabled || (isOptgroup && this.parentNode.disabled);

                    if (icon !== '' && isDisabled) {
                        icon = '<span>' + icon + '</span>';
                    }

                    if (that.options.hideDisabled && isDisabled && !isOptgroup) {
                        liIndex--;
                        return;
                    }

                    if (!$this.data('content')) {
                        // Prepend any icon and append any subtext to the main text.
                        text = icon + '<span class="text">' + text + subtext + '</span>';
                    }

                    if (isOptgroup && $this.data('divider') !== true) {
                        var optGroupClass = ' ' + this.parentNode.className || '';

                        if ($this.index() === 0) { // Is it the first option of the optgroup?
                            optID += 1;

                            // Get the opt group label
                            var label = this.parentNode.label,
                                labelSubtext = typeof $this.parent().data('subtext') !== 'undefined' ? '<small class="text-muted">' + $this.parent().data('subtext') + '</small>' : '',
                                labelIcon = $this.parent().data('icon') ? '<span class="' + that.options.iconBase + ' ' + $this.parent().data('icon') + '"></span> ' : '';

                            label = labelIcon + '<span class="text">' + label + labelSubtext + '</span>';

                            if (index !== 0 && _li.length > 0) { // Is it NOT the first option of the select && are there elements in the dropdown?
                                liIndex++;
                                _li.push(generateLI('', null, 'divider', optID + 'div'));
                            }
                            liIndex++;
                            _li.push(generateLI(label, null, 'dropdown-header' + optGroupClass, optID));
                        }

                        if (that.options.hideDisabled && isDisabled) {
                            liIndex--;
                            return;
                        }

                        _li.push(generateLI(generateA(text, 'opt ' + optionClass + optGroupClass, inline, tokens), index, '', optID));
                    } else if ($this.data('divider') === true) {
                        _li.push(generateLI('', index, 'divider'));
                    } else if ($this.data('hidden') === true) {
                        _li.push(generateLI(generateA(text, optionClass, inline, tokens), index, 'hidden is-hidden'));
                    } else {
                        if (this.previousElementSibling && this.previousElementSibling.tagName === 'OPTGROUP') {
                            liIndex++;
                            _li.push(generateLI('', null, 'divider', optID + 'div'));
                        }
                        _li.push(generateLI(generateA(text, optionClass, inline, tokens), index));
                    }

                    that.liObj[index] = liIndex;
                });

                //If we are not multiple, we don't have a selected item, and we don't have a title, select the first element so something is set in the button
                if (!this.multiple && this.$element.find('option:selected').length === 0 && !this.options.title) {
                    this.$element.find('option').eq(0).prop('selected', true).attr('selected', 'selected');
                }

                return _li.join('');
            },

            findLis: function () {
                if (this.$lis == null) this.$lis = this.$menu.find('li');
                return this.$lis;
            },

            /**
             * @param [updateLi] defaults to true
             */
            render: function (updateLi) {
                var that = this,
                    notDisabled;

                //Update the LI to match the SELECT
                if (updateLi !== false) {
                    this.$element.find('option').each(function (index) {
                        var $lis = that.findLis().eq(that.liObj[index]);

                        that.setDisabled(index, this.disabled || this.parentNode.tagName === 'OPTGROUP' && this.parentNode.disabled, $lis);
                        that.setSelected(index, this.selected, $lis);
                    });
                }

                this.tabIndex();

                var selectedItems = this.$element.find('option').map(function () {
                    if (this.selected) {
                        if (that.options.hideDisabled && (this.disabled || this.parentNode.tagName === 'OPTGROUP' && this.parentNode.disabled)) return;

                        var $this = $(this),
                            icon = $this.data('icon') && that.options.showIcon ? '<i class="' + that.options.iconBase + ' ' + $this.data('icon') + '"></i> ' : '',
                            subtext;

                        if (that.options.showSubtext && $this.data('subtext') && !that.multiple) {
                            subtext = ' <small class="text-muted">' + $this.data('subtext') + '</small>';
                        } else {
                            subtext = '';
                        }
                        if (typeof $this.attr('title') !== 'undefined') {
                            return $this.attr('title');
                        } else if ($this.data('content') && that.options.showContent) {
                            return $this.data('content');
                        } else {
                            return icon + $this.html() + subtext;
                        }
                    }
                }).toArray();

                //Fixes issue in IE10 occurring when no default option is selected and at least one option is disabled
                //Convert all the values into a comma delimited string
                var title = !this.multiple ? selectedItems[0] : selectedItems.join(this.options.multipleSeparator);

                //If this is multi select, and the selectText type is count, the show 1 of 2 selected etc..
                if (this.multiple && this.options.selectedTextFormat.indexOf('count') > -1) {
                    var max = this.options.selectedTextFormat.split('>');
                    if ((max.length > 1 && selectedItems.length > max[1]) || (max.length == 1 && selectedItems.length >= 2)) {
                        notDisabled = this.options.hideDisabled ? ', [disabled]' : '';
                        var totalCount = this.$element.find('option').not('[data-divider="true"], [data-hidden="true"]' + notDisabled).length,
                            tr8nText = (typeof this.options.countSelectedText === 'function') ? this.options.countSelectedText(selectedItems.length, totalCount) : this.options.countSelectedText;
                        title = tr8nText.replace('{0}', selectedItems.length.toString()).replace('{1}', totalCount.toString());
                    }
                }

                if (this.options.title == undefined) {
                    this.options.title = this.$element.attr('title');
                }

                if (this.options.selectedTextFormat == 'static') {
                    title = this.options.title;
                }

                //If we dont have a title, then use the default, or if nothing is set at all, use the not selected text
                if (!title) {
                    title = typeof this.options.title !== 'undefined' ? this.options.title : this.options.noneSelectedText;
                }

                //strip all html-tags and trim the result
                this.$button.attr('title', $.trim(title.replace(/<[^>]*>?/g, '')));
                this.$button.children('.filter-option').html(title);

                this.$element.trigger('rendered.bs.select');
            },

            /**
             * @param [style]
             * @param [status]
             */
            setStyle: function (style, status) {
                if (this.$element.attr('class')) {
                    this.$newElement.addClass(this.$element.attr('class').replace(/selectpicker|mobile-device|bs-select-hidden|validate\[.*\]/gi, ''));
                }

                var buttonClass = style ? style : this.options.style;

                if (status == 'add') {
                    this.$button.addClass(buttonClass);
                } else if (status == 'remove') {
                    this.$button.removeClass(buttonClass);
                } else {
                    this.$button.removeClass(this.options.style);
                    this.$button.addClass(buttonClass);
                }
            },

            liHeight: function (refresh) {
                if (!refresh && (this.options.size === false || this.sizeInfo)) return;

                var newElement = document.createElement('div'),
                    menu = document.createElement('div'),
                    menuInner = document.createElement('ul'),
                    divider = document.createElement('li'),
                    li = document.createElement('li'),
                    a = document.createElement('a'),
                    text = document.createElement('span'),
                    header = this.options.header && this.$menu.find('.popover-title').length > 0 ? this.$menu.find('.popover-title')[0].cloneNode(true) : null,
                    search = this.options.liveSearch ? document.createElement('div') : null,
                    actions = this.options.actionsBox && this.multiple && this.$menu.find('.bs-actionsbox').length > 0 ? this.$menu.find('.bs-actionsbox')[0].cloneNode(true) : null,
                    doneButton = this.options.doneButton && this.multiple && this.$menu.find('.bs-donebutton').length > 0 ? this.$menu.find('.bs-donebutton')[0].cloneNode(true) : null;

                text.className = 'text';
                newElement.className = this.$menu[0].parentNode.className + ' open';
                menu.className = 'dropdown-menu open';
                menuInner.className = 'dropdown-menu inner';
                divider.className = 'divider';

                text.appendChild(document.createTextNode('Inner text'));
                a.appendChild(text);
                li.appendChild(a);
                menuInner.appendChild(li);
                menuInner.appendChild(divider);
                if (header) menu.appendChild(header);
                if (search) {
                    // create a span instead of input as creating an input element is slower
                    var input = document.createElement('span');
                    search.className = 'bs-searchbox';
                    input.className = 'form-control';
                    search.appendChild(input);
                    menu.appendChild(search);
                }
                if (actions) menu.appendChild(actions);
                menu.appendChild(menuInner);
                if (doneButton) menu.appendChild(doneButton);
                newElement.appendChild(menu);

                document.body.appendChild(newElement);

                var liHeight = a.offsetHeight,
                    headerHeight = header ? header.offsetHeight : 0,
                    searchHeight = search ? search.offsetHeight : 0,
                    actionsHeight = actions ? actions.offsetHeight : 0,
                    doneButtonHeight = doneButton ? doneButton.offsetHeight : 0,
                    dividerHeight = $(divider).outerHeight(true),
                    // fall back to jQuery if getComputedStyle is not supported
                    menuStyle = typeof getComputedStyle === 'function' ? getComputedStyle(menu) : false,
                    $menu = menuStyle ? null : $(menu),
                    menuPadding = parseInt(menuStyle ? menuStyle.paddingTop : $menu.css('paddingTop')) +
                                  parseInt(menuStyle ? menuStyle.paddingBottom : $menu.css('paddingBottom')) +
                                  parseInt(menuStyle ? menuStyle.borderTopWidth : $menu.css('borderTopWidth')) +
                                  parseInt(menuStyle ? menuStyle.borderBottomWidth : $menu.css('borderBottomWidth')),
                    menuExtras = menuPadding +
                                  parseInt(menuStyle ? menuStyle.marginTop : $menu.css('marginTop')) +
                                  parseInt(menuStyle ? menuStyle.marginBottom : $menu.css('marginBottom')) + 2;

                document.body.removeChild(newElement);

                this.sizeInfo = {
                    liHeight: liHeight,
                    headerHeight: headerHeight,
                    searchHeight: searchHeight,
                    actionsHeight: actionsHeight,
                    doneButtonHeight: doneButtonHeight,
                    dividerHeight: dividerHeight,
                    menuPadding: menuPadding,
                    menuExtras: menuExtras
                };
            },

            setSize: function () {
                this.findLis();
                this.liHeight();

                if (this.options.header) this.$menu.css('padding-top', 0);
                if (this.options.size === false) return;

                var that = this,
                    $menu = this.$menu,
                    $menuInner = this.$menuInner,
                    $window = $(window),
                    selectHeight = this.$newElement[0].offsetHeight,
                    liHeight = this.sizeInfo['liHeight'],
                    headerHeight = this.sizeInfo['headerHeight'],
                    searchHeight = this.sizeInfo['searchHeight'],
                    actionsHeight = this.sizeInfo['actionsHeight'],
                    doneButtonHeight = this.sizeInfo['doneButtonHeight'],
                    divHeight = this.sizeInfo['dividerHeight'],
                    menuPadding = this.sizeInfo['menuPadding'],
                    menuExtras = this.sizeInfo['menuExtras'],
                    notDisabled = this.options.hideDisabled ? '.disabled' : '',
                    menuHeight,
                    getHeight,
                    selectOffsetTop,
                    selectOffsetBot,
                    posVert = function () {
                        selectOffsetTop = that.$newElement.offset().top - $window.scrollTop();
                        selectOffsetBot = $window.height() - selectOffsetTop - selectHeight;
                    };

                posVert();

                if (this.options.size === 'auto') {
                    var getSize = function () {
                        var minHeight,
                            hasClass = function (className, include) {
                                return function (element) {
                                    if (include) {
                                        return (element.classList ? element.classList.contains(className) : $(element).hasClass(className));
                                    } else {
                                        return !(element.classList ? element.classList.contains(className) : $(element).hasClass(className));
                                    }
                                };
                            },
                            lis = that.$menuInner[0].getElementsByTagName('li'),
                            lisVisible = Array.prototype.filter ? Array.prototype.filter.call(lis, hasClass('hidden', false)) : that.$lis.not('.hidden'),
                            optGroup = Array.prototype.filter ? Array.prototype.filter.call(lisVisible, hasClass('dropdown-header', true)) : lisVisible.filter('.dropdown-header');

                        posVert();
                        menuHeight = selectOffsetBot - menuExtras;

                        if (that.options.container) {
                            if (!$menu.data('height')) $menu.data('height', $menu.height());
                            getHeight = $menu.data('height');
                        } else {
                            getHeight = $menu.height();
                        }

                        if (that.options.dropupAuto) {
                            that.$newElement.toggleClass('dropup', selectOffsetTop > selectOffsetBot && (menuHeight - menuExtras) < getHeight);
                        }
                        if (that.$newElement.hasClass('dropup')) {
                            menuHeight = selectOffsetTop - menuExtras;
                        }

                        if ((lisVisible.length + optGroup.length) > 3) {
                            minHeight = liHeight * 3 + menuExtras - 2;
                        } else {
                            minHeight = 0;
                        }

                        $menu.css({
                            'max-height': menuHeight + 'px',
                            'overflow': 'hidden',
                            'min-height': minHeight + headerHeight + searchHeight + actionsHeight + doneButtonHeight + 'px'
                        });
                        $menuInner.css({
                            'max-height': menuHeight - headerHeight - searchHeight - actionsHeight - doneButtonHeight - menuPadding + 'px',
                            'overflow-y': 'auto',
                            'min-height': Math.max(minHeight - menuPadding, 0) + 'px'
                        });
                    };
                    getSize();
                    this.$searchbox.off('input.getSize propertychange.getSize').on('input.getSize propertychange.getSize', getSize);
                    $window.off('resize.getSize scroll.getSize').on('resize.getSize scroll.getSize', getSize);
                } else if (this.options.size && this.options.size != 'auto' && this.$lis.not(notDisabled).length > this.options.size) {
                    var optIndex = this.$lis.not('.divider').not(notDisabled).children().slice(0, this.options.size).last().parent().index(),
                        divLength = this.$lis.slice(0, optIndex + 1).filter('.divider').length;
                    menuHeight = liHeight * this.options.size + divLength * divHeight + menuPadding;

                    if (that.options.container) {
                        if (!$menu.data('height')) $menu.data('height', $menu.height());
                        getHeight = $menu.data('height');
                    } else {
                        getHeight = $menu.height();
                    }

                    if (that.options.dropupAuto) {
                        //noinspection JSUnusedAssignment
                        this.$newElement.toggleClass('dropup', selectOffsetTop > selectOffsetBot && (menuHeight - menuExtras) < getHeight);
                    }
                    $menu.css({
                        'max-height': menuHeight + headerHeight + searchHeight + actionsHeight + doneButtonHeight + 'px',
                        'overflow': 'hidden',
                        'min-height': ''
                    });
                    $menuInner.css({
                        'max-height': menuHeight - menuPadding + 'px',
                        'overflow-y': 'auto',
                        'min-height': ''
                    });
                }
            },

            setWidth: function () {
                if (this.options.width === 'auto') {
                    this.$menu.css('min-width', '0');

                    // Get correct width if element is hidden
                    var $selectClone = this.$menu.parent().clone().appendTo('body'),
                        $selectClone2 = this.options.container ? this.$newElement.clone().appendTo('body') : $selectClone,
                        ulWidth = $selectClone.children('.dropdown-menu').outerWidth(),
                        btnWidth = $selectClone2.css('width', 'auto').children('button').outerWidth();

                    $selectClone.remove();
                    $selectClone2.remove();

                    // Set width to whatever's larger, button title or longest option
                    this.$newElement.css('width', Math.max(ulWidth, btnWidth) + 'px');
                } else if (this.options.width === 'fit') {
                    // Remove inline min-width so width can be changed from 'auto'
                    this.$menu.css('min-width', '');
                    this.$newElement.css('width', '').addClass('fit-width');
                } else if (this.options.width) {
                    // Remove inline min-width so width can be changed from 'auto'
                    this.$menu.css('min-width', '');
                    this.$newElement.css('width', this.options.width);
                } else {
                    // Remove inline min-width/width so width can be changed
                    this.$menu.css('min-width', '');
                    this.$newElement.css('width', '');
                }
                // Remove fit-width class if width is changed programmatically
                if (this.$newElement.hasClass('fit-width') && this.options.width !== 'fit') {
                    this.$newElement.removeClass('fit-width');
                }
            },

            selectPosition: function () {
                this.$bsContainer = $('<div class="bs-container" />');

                var that = this,
                    pos,
                    actualHeight,
                    getPlacement = function ($element) {
                        that.$bsContainer.addClass($element.attr('class').replace(/form-control|fit-width/gi, '')).toggleClass('dropup', $element.hasClass('dropup'));
                        pos = $element.offset();
                        actualHeight = $element.hasClass('dropup') ? 0 : $element[0].offsetHeight;
                        that.$bsContainer.css({
                            'top': pos.top + actualHeight,
                            'left': pos.left,
                            'width': $element[0].offsetWidth
                        });
                    };

                this.$button.on('click', function () {
                    var $this = $(this);

                    if (that.isDisabled()) {
                        return;
                    }

                    getPlacement(that.$newElement);

                    that.$bsContainer
                      .appendTo(that.options.container)
                      .toggleClass('open', !$this.hasClass('open'))
                      .append(that.$menu);
                });

                $(window).on('resize scroll', function () {
                    getPlacement(that.$newElement);
                });

                this.$element.on('hide.bs.select', function () {
                    that.$menu.data('height', that.$menu.height());
                    that.$bsContainer.detach();
                });
            },

            setSelected: function (index, selected, $lis) {
                if (!$lis) {
                    $lis = this.findLis().eq(this.liObj[index]);
                }

                $lis.toggleClass('selected', selected);
            },

            setDisabled: function (index, disabled, $lis) {
                if (!$lis) {
                    $lis = this.findLis().eq(this.liObj[index]);
                }

                if (disabled) {
                    $lis.addClass('disabled').children('a').attr('href', '#').attr('tabindex', -1);
                } else {
                    $lis.removeClass('disabled').children('a').removeAttr('href').attr('tabindex', 0);
                }
            },

            isDisabled: function () {
                return this.$element[0].disabled;
            },

            checkDisabled: function () {
                var that = this;

                if (this.isDisabled()) {
                    this.$newElement.addClass('disabled');
                    this.$button.addClass('disabled').attr('tabindex', -1);
                } else {
                    if (this.$button.hasClass('disabled')) {
                        this.$newElement.removeClass('disabled');
                        this.$button.removeClass('disabled');
                    }

                    if (this.$button.attr('tabindex') == -1 && !this.$element.data('tabindex')) {
                        this.$button.removeAttr('tabindex');
                    }
                }

                this.$button.click(function () {
                    return !that.isDisabled();
                });
            },

            tabIndex: function () {
                if (this.$element.data('tabindex') !== this.$element.attr('tabindex') &&
                  (this.$element.attr('tabindex') !== -98 && this.$element.attr('tabindex') !== '-98')) {
                    this.$element.data('tabindex', this.$element.attr('tabindex'));
                    this.$button.attr('tabindex', this.$element.data('tabindex'));
                }

                this.$element.attr('tabindex', -98);
            },

            clickListener: function () {
                var that = this,
                    $document = $(document);

                this.$newElement.on('touchstart.dropdown', '.dropdown-menu', function (e) {
                    e.stopPropagation();
                });

                $document.data('spaceSelect', false);

                this.$button.on('keyup', function (e) {
                    if (/(32)/.test(e.keyCode.toString(10)) && $document.data('spaceSelect')) {
                        e.preventDefault();
                        $document.data('spaceSelect', false);
                    }
                });

                this.$button.on('click', function () {
                    that.setSize();
                });

                this.$element.on('shown.bs.select', function () {
                    if (!that.options.liveSearch && !that.multiple) {
                        that.$menuInner.find('.selected a').focus();
                    } else if (!that.multiple) {
                        var selectedIndex = that.liObj[that.$element[0].selectedIndex];

                        if (typeof selectedIndex !== 'number' || that.options.size === false) return;

                        // scroll to selected option
                        var offset = that.$lis.eq(selectedIndex)[0].offsetTop - that.$menuInner[0].offsetTop;
                        offset = offset - that.$menuInner[0].offsetHeight / 2 + that.sizeInfo.liHeight / 2;
                        that.$menuInner[0].scrollTop = offset;
                    }
                });

                this.$menuInner.on('click', 'li a', function (e) {
                    var $this = $(this),
                        clickedIndex = $this.parent().data('originalIndex'),
                        prevValue = that.$element.val(),
                        prevIndex = that.$element.prop('selectedIndex');

                    // Don't close on multi choice menu
                    if (that.multiple) {
                        e.stopPropagation();
                    }

                    e.preventDefault();

                    //Don't run if we have been disabled
                    if (!that.isDisabled() && !$this.parent().hasClass('disabled')) {
                        var $options = that.$element.find('option'),
                            $option = $options.eq(clickedIndex),
                            state = $option.prop('selected'),
                            $optgroup = $option.parent('optgroup'),
                            maxOptions = that.options.maxOptions,
                            maxOptionsGrp = $optgroup.data('maxOptions') || false;

                        if (!that.multiple) { // Deselect all others if not multi select box
                            $options.prop('selected', false);
                            $option.prop('selected', true);
                            that.$menuInner.find('.selected').removeClass('selected');
                            that.setSelected(clickedIndex, true);
                        } else { // Toggle the one we have chosen if we are multi select.
                            $option.prop('selected', !state);
                            that.setSelected(clickedIndex, !state);
                            $this.blur();

                            if (maxOptions !== false || maxOptionsGrp !== false) {
                                var maxReached = maxOptions < $options.filter(':selected').length,
                                    maxReachedGrp = maxOptionsGrp < $optgroup.find('option:selected').length;

                                if ((maxOptions && maxReached) || (maxOptionsGrp && maxReachedGrp)) {
                                    if (maxOptions && maxOptions == 1) {
                                        $options.prop('selected', false);
                                        $option.prop('selected', true);
                                        that.$menuInner.find('.selected').removeClass('selected');
                                        that.setSelected(clickedIndex, true);
                                    } else if (maxOptionsGrp && maxOptionsGrp == 1) {
                                        $optgroup.find('option:selected').prop('selected', false);
                                        $option.prop('selected', true);
                                        var optgroupID = $this.parent().data('optgroup');
                                        that.$menuInner.find('[data-optgroup="' + optgroupID + '"]').removeClass('selected');
                                        that.setSelected(clickedIndex, true);
                                    } else {
                                        var maxOptionsArr = (typeof that.options.maxOptionsText === 'function') ?
                                                that.options.maxOptionsText(maxOptions, maxOptionsGrp) : that.options.maxOptionsText,
                                            maxTxt = maxOptionsArr[0].replace('{n}', maxOptions),
                                            maxTxtGrp = maxOptionsArr[1].replace('{n}', maxOptionsGrp),
                                            $notify = $('<div class="notify"></div>');
                                        // If {var} is set in array, replace it
                                        /** @deprecated */
                                        if (maxOptionsArr[2]) {
                                            maxTxt = maxTxt.replace('{var}', maxOptionsArr[2][maxOptions > 1 ? 0 : 1]);
                                            maxTxtGrp = maxTxtGrp.replace('{var}', maxOptionsArr[2][maxOptionsGrp > 1 ? 0 : 1]);
                                        }

                                        $option.prop('selected', false);

                                        that.$menu.append($notify);

                                        if (maxOptions && maxReached) {
                                            $notify.append($('<div>' + maxTxt + '</div>'));
                                            that.$element.trigger('maxReached.bs.select');
                                        }

                                        if (maxOptionsGrp && maxReachedGrp) {
                                            $notify.append($('<div>' + maxTxtGrp + '</div>'));
                                            that.$element.trigger('maxReachedGrp.bs.select');
                                        }

                                        setTimeout(function () {
                                            that.setSelected(clickedIndex, false);
                                        }, 10);

                                        $notify.delay(750).fadeOut(300, function () {
                                            $(this).remove();
                                        });
                                    }
                                }
                            }
                        }

                        if (!that.multiple) {
                            that.$button.focus();
                        } else if (that.options.liveSearch) {
                            that.$searchbox.focus();
                        }

                        // Trigger select 'change'
                        if ((prevValue != that.$element.val() && that.multiple) || (prevIndex != that.$element.prop('selectedIndex') && !that.multiple)) {
                            // $option.prop('selected') is current option state (selected/unselected). state is previous option state.
                            that.$element
                              .trigger('changed.bs.select', [clickedIndex, $option.prop('selected'), state])
                              .triggerNative('change');
                        }
                    }
                });

                this.$menu.on('click', 'li.disabled a, .popover-title, .popover-title :not(.close)', function (e) {
                    if (e.currentTarget == this) {
                        e.preventDefault();
                        e.stopPropagation();
                        if (that.options.liveSearch && !$(e.target).hasClass('close')) {
                            that.$searchbox.focus();
                        } else {
                            that.$button.focus();
                        }
                    }
                });

                this.$menuInner.on('click', '.divider, .dropdown-header', function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                    if (that.options.liveSearch) {
                        that.$searchbox.focus();
                    } else {
                        that.$button.focus();
                    }
                });

                this.$menu.on('click', '.popover-title .close', function () {
                    that.$button.click();
                });

                this.$searchbox.on('click', function (e) {
                    e.stopPropagation();
                });

                this.$menu.on('click', '.actions-btn', function (e) {
                    if (that.options.liveSearch) {
                        that.$searchbox.focus();
                    } else {
                        that.$button.focus();
                    }

                    e.preventDefault();
                    e.stopPropagation();

                    if ($(this).hasClass('bs-select-all')) {
                        that.selectAll();
                    } else {
                        that.deselectAll();
                    }
                });

                this.$element.change(function () {
                    that.render(false);
                });
            },

            liveSearchListener: function () {
                var that = this,
                    $no_results = $('<li class="no-results"></li>');

                this.$button.on('click.dropdown.data-api touchstart.dropdown.data-api', function () {
                    that.$menuInner.find('.active').removeClass('active');
                    if (!!that.$searchbox.val()) {
                        that.$searchbox.val('');
                        that.$lis.not('.is-hidden').removeClass('hidden');
                        if (!!$no_results.parent().length) $no_results.remove();
                    }
                    if (!that.multiple) that.$menuInner.find('.selected').addClass('active');
                    setTimeout(function () {
                        that.$searchbox.focus();
                    }, 10);
                });

                this.$searchbox.on('click.dropdown.data-api focus.dropdown.data-api touchend.dropdown.data-api', function (e) {
                    e.stopPropagation();
                });

                this.$searchbox.on('input propertychange', function () {
                    if (that.$searchbox.val()) {
                        var $searchBase = that.$lis.not('.is-hidden').removeClass('hidden').children('a');
                        if (that.options.liveSearchNormalize) {
                            $searchBase = $searchBase.not(':a' + that._searchStyle() + '("' + normalizeToBase(that.$searchbox.val()) + '")');
                        } else {
                            $searchBase = $searchBase.not(':' + that._searchStyle() + '("' + that.$searchbox.val() + '")');
                        }
                        $searchBase.parent().addClass('hidden');

                        that.$lis.filter('.dropdown-header').each(function () {
                            var $this = $(this),
                                optgroup = $this.data('optgroup');

                            if (that.$lis.filter('[data-optgroup=' + optgroup + ']').not($this).not('.hidden').length === 0) {
                                $this.addClass('hidden');
                                that.$lis.filter('[data-optgroup=' + optgroup + 'div]').addClass('hidden');
                            }
                        });

                        var $lisVisible = that.$lis.not('.hidden');

                        // hide divider if first or last visible, or if followed by another divider
                        $lisVisible.each(function (index) {
                            var $this = $(this);

                            if ($this.hasClass('divider') && (
                              $this.index() === $lisVisible.first().index() ||
                              $this.index() === $lisVisible.last().index() ||
                              $lisVisible.eq(index + 1).hasClass('divider'))) {
                                $this.addClass('hidden');
                            }
                        });

                        if (!that.$lis.not('.hidden, .no-results').length) {
                            if (!!$no_results.parent().length) {
                                $no_results.remove();
                            }
                            $no_results.html(that.options.noneResultsText.replace('{0}', '"' + htmlEscape(that.$searchbox.val()) + '"')).show();
                            that.$menuInner.append($no_results);
                        } else if (!!$no_results.parent().length) {
                            $no_results.remove();
                        }
                    } else {
                        that.$lis.not('.is-hidden').removeClass('hidden');
                        if (!!$no_results.parent().length) {
                            $no_results.remove();
                        }
                    }

                    that.$lis.filter('.active').removeClass('active');
                    if (that.$searchbox.val()) that.$lis.not('.hidden, .divider, .dropdown-header').eq(0).addClass('active').children('a').focus();
                    $(this).focus();
                });
            },

            _searchStyle: function () {
                var styles = {
                    begins: 'ibegins',
                    startsWith: 'ibegins'
                };

                return styles[this.options.liveSearchStyle] || 'icontains';
            },

            val: function (value) {
                if (typeof value !== 'undefined') {
                    this.$element.val(value);
                    this.render();

                    return this.$element;
                } else {
                    return this.$element.val();
                }
            },

            changeAll: function (status) {
                if (typeof status === 'undefined') status = true;

                this.findLis();

                var $options = this.$element.find('option'),
                    $lisVisible = this.$lis.not('.divider, .dropdown-header, .disabled, .hidden').toggleClass('selected', status),
                    lisVisLen = $lisVisible.length,
                    selectedOptions = [];

                for (var i = 0; i < lisVisLen; i++) {
                    var origIndex = $lisVisible[i].getAttribute('data-original-index');
                    selectedOptions[selectedOptions.length] = $options.eq(origIndex)[0];
                }

                $(selectedOptions).prop('selected', status);

                this.render(false);

                this.$element
                  .trigger('changed.bs.select')
                  .triggerNative('change');
            },

            selectAll: function () {
                return this.changeAll(true);
            },

            deselectAll: function () {
                return this.changeAll(false);
            },

            toggle: function (e) {
                e = e || window.event;

                if (e) e.stopPropagation();

                this.$button.trigger('click');
            },

            keydown: function (e) {
                var $this = $(this),
                    $parent = $this.is('input') ? $this.parent().parent() : $this.parent(),
                    $items,
                    that = $parent.data('this'),
                    index,
                    next,
                    first,
                    last,
                    prev,
                    nextPrev,
                    prevIndex,
                    isActive,
                    selector = ':not(.disabled, .hidden, .dropdown-header, .divider)',
                    keyCodeMap = {
                        32: ' ',
                        48: '0',
                        49: '1',
                        50: '2',
                        51: '3',
                        52: '4',
                        53: '5',
                        54: '6',
                        55: '7',
                        56: '8',
                        57: '9',
                        59: ';',
                        65: 'a',
                        66: 'b',
                        67: 'c',
                        68: 'd',
                        69: 'e',
                        70: 'f',
                        71: 'g',
                        72: 'h',
                        73: 'i',
                        74: 'j',
                        75: 'k',
                        76: 'l',
                        77: 'm',
                        78: 'n',
                        79: 'o',
                        80: 'p',
                        81: 'q',
                        82: 'r',
                        83: 's',
                        84: 't',
                        85: 'u',
                        86: 'v',
                        87: 'w',
                        88: 'x',
                        89: 'y',
                        90: 'z',
                        96: '0',
                        97: '1',
                        98: '2',
                        99: '3',
                        100: '4',
                        101: '5',
                        102: '6',
                        103: '7',
                        104: '8',
                        105: '9'
                    };

                if (that.options.liveSearch) $parent = $this.parent().parent();

                if (that.options.container) $parent = that.$menu;

                $items = $('[role=menu] li', $parent);

                isActive = that.$newElement.hasClass('open');

                if (!isActive && (e.keyCode >= 48 && e.keyCode <= 57 || e.keyCode >= 96 && e.keyCode <= 105 || e.keyCode >= 65 && e.keyCode <= 90)) {
                    if (!that.options.container) {
                        that.setSize();
                        that.$menu.parent().addClass('open');
                        isActive = true;
                    } else {
                        that.$button.trigger('click');
                    }
                    that.$searchbox.focus();
                }

                if (that.options.liveSearch) {
                    if (/(^9$|27)/.test(e.keyCode.toString(10)) && isActive && that.$menu.find('.active').length === 0) {
                        e.preventDefault();
                        that.$menu.parent().removeClass('open');
                        if (that.options.container) that.$newElement.removeClass('open');
                        that.$button.focus();
                    }
                    // $items contains li elements when liveSearch is enabled
                    $items = $('[role=menu] li' + selector, $parent);
                    if (!$this.val() && !/(38|40)/.test(e.keyCode.toString(10))) {
                        if ($items.filter('.active').length === 0) {
                            $items = that.$menuInner.find('li');
                            if (that.options.liveSearchNormalize) {
                                $items = $items.filter(':a' + that._searchStyle() + '(' + normalizeToBase(keyCodeMap[e.keyCode]) + ')');
                            } else {
                                $items = $items.filter(':' + that._searchStyle() + '(' + keyCodeMap[e.keyCode] + ')');
                            }
                        }
                    }
                }

                if (!$items.length) return;

                if (/(38|40)/.test(e.keyCode.toString(10))) {
                    index = $items.index($items.find('a').filter(':focus').parent());
                    first = $items.filter(selector).first().index();
                    last = $items.filter(selector).last().index();
                    next = $items.eq(index).nextAll(selector).eq(0).index();
                    prev = $items.eq(index).prevAll(selector).eq(0).index();
                    nextPrev = $items.eq(next).prevAll(selector).eq(0).index();

                    if (that.options.liveSearch) {
                        $items.each(function (i) {
                            if (!$(this).hasClass('disabled')) {
                                $(this).data('index', i);
                            }
                        });
                        index = $items.index($items.filter('.active'));
                        first = $items.first().data('index');
                        last = $items.last().data('index');
                        next = $items.eq(index).nextAll().eq(0).data('index');
                        prev = $items.eq(index).prevAll().eq(0).data('index');
                        nextPrev = $items.eq(next).prevAll().eq(0).data('index');
                    }

                    prevIndex = $this.data('prevIndex');

                    if (e.keyCode == 38) {
                        if (that.options.liveSearch) index--;
                        if (index != nextPrev && index > prev) index = prev;
                        if (index < first) index = first;
                        if (index == prevIndex) index = last;
                    } else if (e.keyCode == 40) {
                        if (that.options.liveSearch) index++;
                        if (index == -1) index = 0;
                        if (index != nextPrev && index < next) index = next;
                        if (index > last) index = last;
                        if (index == prevIndex) index = first;
                    }

                    $this.data('prevIndex', index);

                    if (!that.options.liveSearch) {
                        $items.eq(index).children('a').focus();
                    } else {
                        e.preventDefault();
                        if (!$this.hasClass('dropdown-toggle')) {
                            $items.removeClass('active').eq(index).addClass('active').children('a').focus();
                            $this.focus();
                        }
                    }

                } else if (!$this.is('input')) {
                    var keyIndex = [],
                        count,
                        prevKey;

                    $items.each(function () {
                        if (!$(this).hasClass('disabled')) {
                            if ($.trim($(this).children('a').text().toLowerCase()).substring(0, 1) == keyCodeMap[e.keyCode]) {
                                keyIndex.push($(this).index());
                            }
                        }
                    });

                    count = $(document).data('keycount');
                    count++;
                    $(document).data('keycount', count);

                    prevKey = $.trim($(':focus').text().toLowerCase()).substring(0, 1);

                    if (prevKey != keyCodeMap[e.keyCode]) {
                        count = 1;
                        $(document).data('keycount', count);
                    } else if (count >= keyIndex.length) {
                        $(document).data('keycount', 0);
                        if (count > keyIndex.length) count = 1;
                    }

                    $items.eq(keyIndex[count - 1]).children('a').focus();
                }

                // Select focused option if "Enter", "Spacebar" or "Tab" (when selectOnTab is true) are pressed inside the menu.
                if ((/(13|32)/.test(e.keyCode.toString(10)) || (/(^9$)/.test(e.keyCode.toString(10)) && that.options.selectOnTab)) && isActive) {
                    if (!/(32)/.test(e.keyCode.toString(10))) e.preventDefault();
                    if (!that.options.liveSearch) {
                        var elem = $(':focus');
                        elem.click();
                        // Bring back focus for multiselects
                        elem.focus();
                        // Prevent screen from scrolling if the user hit the spacebar
                        e.preventDefault();
                        // Fixes spacebar selection of dropdown items in FF & IE
                        $(document).data('spaceSelect', true);
                    } else if (!/(32)/.test(e.keyCode.toString(10))) {
                        that.$menuInner.find('.active a').click();
                        $this.focus();
                    }
                    $(document).data('keycount', 0);
                }

                if ((/(^9$|27)/.test(e.keyCode.toString(10)) && isActive && (that.multiple || that.options.liveSearch)) || (/(27)/.test(e.keyCode.toString(10)) && !isActive)) {
                    that.$menu.parent().removeClass('open');
                    if (that.options.container) that.$newElement.removeClass('open');
                    that.$button.focus();
                }
            },

            mobile: function () {
                this.$element.addClass('mobile-device');
            },

            refresh: function () {
                this.$lis = null;
                this.liObj = {};
                this.reloadLi();
                this.render();
                this.checkDisabled();
                this.liHeight(true);
                this.setStyle();
                this.setWidth();
                if (this.$lis) this.$searchbox.trigger('propertychange');

                this.$element.trigger('refreshed.bs.select');
            },

            hide: function () {
                this.$newElement.hide();
            },

            show: function () {
                this.$newElement.show();
            },

            remove: function () {
                this.$newElement.remove();
                this.$element.remove();
            },

            destroy: function () {
                this.$newElement.before(this.$element).remove();

                if (this.$bsContainer) {
                    this.$bsContainer.remove();
                } else {
                    this.$menu.remove();
                }

                this.$element
                  .off('.bs.select')
                  .removeData('selectpicker')
                  .removeClass('bs-select-hidden selectpicker');
            }
        };

        // SELECTPICKER PLUGIN DEFINITION
        // ==============================
        function Plugin(option, event) {
            // get the args of the outer function..
            var args = arguments;
            // The arguments of the function are explicitly re-defined from the argument list, because the shift causes them
            // to get lost/corrupted in android 2.3 and IE9 #715 #775
            var _option = option,
                _event = event;
            [].shift.apply(args);

            var value;
            var chain = this.each(function () {
                var $this = $(this);
                if ($this.is('select')) {
                    var data = $this.data('selectpicker'),
                        options = typeof _option == 'object' && _option;

                    if (!data) {
                        var config = $.extend({}, Selectpicker.DEFAULTS, $.fn.selectpicker.defaults || {}, $this.data(), options);
                        config.template = $.extend({}, Selectpicker.DEFAULTS.template, ($.fn.selectpicker.defaults ? $.fn.selectpicker.defaults.template : {}), $this.data().template, options.template);
                        $this.data('selectpicker', (data = new Selectpicker(this, config, _event)));
                    } else if (options) {
                        for (var i in options) {
                            if (options.hasOwnProperty(i)) {
                                data.options[i] = options[i];
                            }
                        }
                    }

                    if (typeof _option == 'string') {
                        if (data[_option] instanceof Function) {
                            value = data[_option].apply(data, args);
                        } else {
                            value = data.options[_option];
                        }
                    }
                }
            });

            if (typeof value !== 'undefined') {
                //noinspection JSUnusedAssignment
                return value;
            } else {
                return chain;
            }
        }

        var old = $.fn.selectpicker;
        $.fn.selectpicker = Plugin;
        $.fn.selectpicker.Constructor = Selectpicker;

        // SELECTPICKER NO CONFLICT
        // ========================
        $.fn.selectpicker.noConflict = function () {
            $.fn.selectpicker = old;
            return this;
        };

        $(document)
            .data('keycount', 0)
            .on('keydown.bs.select', '.bootstrap-select [data-toggle=dropdown], .bootstrap-select [role="menu"], .bs-searchbox input', Selectpicker.prototype.keydown)
            .on('focusin.modal', '.bootstrap-select [data-toggle=dropdown], .bootstrap-select [role="menu"], .bs-searchbox input', function (e) {
                e.stopPropagation();
            });

        // SELECTPICKER DATA-API
        // =====================
        $(window).on('load.bs.select.data-api', function () {
            $('.selectpicker').each(function () {
                var $selectpicker = $(this);
                Plugin.call($selectpicker, $selectpicker.data());
            })
        });
    })(jQuery);


}));

	

// ******************************
//
// 		Datepicker
//
// ******************************
!function (t, e) { function i() { return new Date(Date.UTC.apply(Date, arguments)) } function a() { var t = new Date; return i(t.getFullYear(), t.getMonth(), t.getDate()) } function s(t) { return function () { return this[t].apply(this, arguments) } } function n(e, i) { function a(t, e) { return e.toLowerCase() } var s, n = t(e).data(), r = {}, h = new RegExp("^" + i.toLowerCase() + "([A-Z])"); i = new RegExp("^" + i.toLowerCase()); for (var o in n) i.test(o) && (s = o.replace(h, a), r[s] = n[o]); return r } function r(e) { var i = {}; if (f[e] || (e = e.split("-")[0], f[e])) { var a = f[e]; return t.each(p, function (t, e) { e in a && (i[e] = a[e]) }), i } } var h = t(window), o = function () { var e = { get: function (t) { return this.slice(t)[0] }, contains: function (t) { for (var e = t && t.valueOf(), i = 0, a = this.length; a > i; i++) if (this[i].valueOf() === e) return i; return -1 }, remove: function (t) { this.splice(t, 1) }, replace: function (e) { e && (t.isArray(e) || (e = [e]), this.clear(), this.push.apply(this, e)) }, clear: function () { this.splice(0) }, copy: function () { var t = new o; return t.replace(this), t } }; return function () { var i = []; return i.push.apply(i, arguments), t.extend(i, e), i } }(), d = function (e, i) { this.dates = new o, this.viewDate = a(), this.focusDate = null, this._process_options(i), this.element = t(e), this.isInline = !1, this.isInput = this.element.is("input"), this.component = this.element.is(".date") ? this.element.find(".add-on, .input-group-addon, .btn") : !1, this.hasInput = this.component && this.element.find("input").length, this.component && 0 === this.component.length && (this.component = !1), this.picker = t(g.template), this._buildEvents(), this._attachEvents(), this.isInline ? this.picker.addClass("datepicker-inline").appendTo(this.element) : this.picker.addClass("datepicker-dropdown dropdown-menu"), this.o.rtl && this.picker.addClass("datepicker-rtl"), this.viewMode = this.o.startView, this.o.calendarWeeks && this.picker.find("tfoot th.today").attr("colspan", function (t, e) { return parseInt(e) + 1 }), this._allow_update = !1, this.setStartDate(this._o.startDate), this.setEndDate(this._o.endDate), this.setDaysOfWeekDisabled(this.o.daysOfWeekDisabled), this.fillDow(), this.fillMonths(), this._allow_update = !0, this.update(), this.showMode(), this.isInline && this.show() }; d.prototype = { constructor: d, _process_options: function (e) { this._o = t.extend({}, this._o, e); var i = this.o = t.extend({}, this._o), a = i.language; switch (f[a] || (a = a.split("-")[0], f[a] || (a = u.language)), i.language = a, i.startView) { case 2: case "decade": i.startView = 2; break; case 1: case "year": i.startView = 1; break; default: i.startView = 0 } switch (i.minViewMode) { case 1: case "months": i.minViewMode = 1; break; case 2: case "years": i.minViewMode = 2; break; default: i.minViewMode = 0 } i.startView = Math.max(i.startView, i.minViewMode), i.multidate !== !0 && (i.multidate = Number(i.multidate) || !1, i.multidate = i.multidate !== !1 ? Math.max(0, i.multidate) : 1), i.multidateSeparator = String(i.multidateSeparator), i.weekStart %= 7, i.weekEnd = (i.weekStart + 6) % 7; var s = g.parseFormat(i.format); i.startDate !== -1 / 0 && (i.startDate = i.startDate ? i.startDate instanceof Date ? this._local_to_utc(this._zero_time(i.startDate)) : g.parseDate(i.startDate, s, i.language) : -1 / 0), 1 / 0 !== i.endDate && (i.endDate = i.endDate ? i.endDate instanceof Date ? this._local_to_utc(this._zero_time(i.endDate)) : g.parseDate(i.endDate, s, i.language) : 1 / 0), i.daysOfWeekDisabled = i.daysOfWeekDisabled || [], t.isArray(i.daysOfWeekDisabled) || (i.daysOfWeekDisabled = i.daysOfWeekDisabled.split(/[,\s]*/)), i.daysOfWeekDisabled = t.map(i.daysOfWeekDisabled, function (t) { return parseInt(t, 10) }); var n = String(i.orientation).toLowerCase().split(/\s+/g), r = i.orientation.toLowerCase(); if (n = t.grep(n, function (t) { return /^auto|left|right|top|bottom$/.test(t) }), i.orientation = { x: "auto", y: "auto" }, r && "auto" !== r) if (1 === n.length) switch (n[0]) { case "top": case "bottom": i.orientation.y = n[0]; break; case "left": case "right": i.orientation.x = n[0] } else r = t.grep(n, function (t) { return /^left|right$/.test(t) }), i.orientation.x = r[0] || "auto", r = t.grep(n, function (t) { return /^top|bottom$/.test(t) }), i.orientation.y = r[0] || "auto"; else; }, _events: [], _secondaryEvents: [], _applyEvents: function (t) { for (var i, a, s, n = 0; n < t.length; n++) i = t[n][0], 2 === t[n].length ? (a = e, s = t[n][1]) : 3 === t[n].length && (a = t[n][1], s = t[n][2]), i.on(s, a) }, _unapplyEvents: function (t) { for (var i, a, s, n = 0; n < t.length; n++) i = t[n][0], 2 === t[n].length ? (s = e, a = t[n][1]) : 3 === t[n].length && (s = t[n][1], a = t[n][2]), i.off(a, s) }, _buildEvents: function () { this.isInput ? this._events = [[this.element, { focus: t.proxy(this.show, this), keyup: t.proxy(function (e) { -1 === t.inArray(e.keyCode, [27, 37, 39, 38, 40, 32, 13, 9]) && this.update() }, this), keydown: t.proxy(this.keydown, this) }]] : this.component && this.hasInput ? this._events = [[this.element.find("input"), { focus: t.proxy(this.show, this), keyup: t.proxy(function (e) { -1 === t.inArray(e.keyCode, [27, 37, 39, 38, 40, 32, 13, 9]) && this.update() }, this), keydown: t.proxy(this.keydown, this) }], [this.component, { click: t.proxy(this.show, this) }]] : this.element.is("div") ? this.isInline = !0 : this._events = [[this.element, { click: t.proxy(this.show, this) }]], this._events.push([this.element, "*", { blur: t.proxy(function (t) { this._focused_from = t.target }, this) }], [this.element, { blur: t.proxy(function (t) { this._focused_from = t.target }, this) }]), this._secondaryEvents = [[this.picker, { click: t.proxy(this.click, this) }], [t(window), { resize: t.proxy(this.place, this) }], [t(document), { "mousedown touchstart": t.proxy(function (t) { this.element.is(t.target) || this.element.find(t.target).length || this.picker.is(t.target) || this.picker.find(t.target).length || this.hide() }, this) }]] }, _attachEvents: function () { this._detachEvents(), this._applyEvents(this._events) }, _detachEvents: function () { this._unapplyEvents(this._events) }, _attachSecondaryEvents: function () { this._detachSecondaryEvents(), this._applyEvents(this._secondaryEvents) }, _detachSecondaryEvents: function () { this._unapplyEvents(this._secondaryEvents) }, _trigger: function (e, i) { var a = i || this.dates.get(-1), s = this._utc_to_local(a); this.element.trigger({ type: e, date: s, dates: t.map(this.dates, this._utc_to_local), format: t.proxy(function (t, e) { 0 === arguments.length ? (t = this.dates.length - 1, e = this.o.format) : "string" == typeof t && (e = t, t = this.dates.length - 1), e = e || this.o.format; var i = this.dates.get(t); return g.formatDate(i, e, this.o.language) }, this) }) }, show: function () { this.isInline || this.picker.appendTo("body"), this.picker.show(), this.place(), this._attachSecondaryEvents(), this._trigger("show") }, hide: function () { this.isInline || this.picker.is(":visible") && (this.focusDate = null, this.picker.hide().detach(), this._detachSecondaryEvents(), this.viewMode = this.o.startView, this.showMode(), this.o.forceParse && (this.isInput && this.element.val() || this.hasInput && this.element.find("input").val()) && this.setValue(), this._trigger("hide")) }, remove: function () { this.hide(), this._detachEvents(), this._detachSecondaryEvents(), this.picker.remove(), delete this.element.data().datepicker, this.isInput || delete this.element.data().date }, _utc_to_local: function (t) { return t && new Date(t.getTime() + 6e4 * t.getTimezoneOffset()) }, _local_to_utc: function (t) { return t && new Date(t.getTime() - 6e4 * t.getTimezoneOffset()) }, _zero_time: function (t) { return t && new Date(t.getFullYear(), t.getMonth(), t.getDate()) }, _zero_utc_time: function (t) { return t && new Date(Date.UTC(t.getUTCFullYear(), t.getUTCMonth(), t.getUTCDate())) }, getDates: function () { return t.map(this.dates, this._utc_to_local) }, getUTCDates: function () { return t.map(this.dates, function (t) { return new Date(t) }) }, getDate: function () { return this._utc_to_local(this.getUTCDate()) }, getUTCDate: function () { return new Date(this.dates.get(-1)) }, setDates: function () { var e = t.isArray(arguments[0]) ? arguments[0] : arguments; this.update.apply(this, e), this._trigger("changeDate"), this.setValue() }, setUTCDates: function () { var e = t.isArray(arguments[0]) ? arguments[0] : arguments; this.update.apply(this, t.map(e, this._utc_to_local)), this._trigger("changeDate"), this.setValue() }, setDate: s("setDates"), setUTCDate: s("setUTCDates"), setValue: function () { var t = this.getFormattedDate(); this.isInput ? this.element.val(t).change() : this.component && this.element.find("input").val(t).change() }, getFormattedDate: function (i) { i === e && (i = this.o.format); var a = this.o.language; return t.map(this.dates, function (t) { return g.formatDate(t, i, a) }).join(this.o.multidateSeparator) }, setStartDate: function (t) { this._process_options({ startDate: t }), this.update(), this.updateNavArrows() }, setEndDate: function (t) { this._process_options({ endDate: t }), this.update(), this.updateNavArrows() }, setDaysOfWeekDisabled: function (t) { this._process_options({ daysOfWeekDisabled: t }), this.update(), this.updateNavArrows() }, place: function () { if (!this.isInline) { var e = this.picker.outerWidth(), i = this.picker.outerHeight(), a = 10, s = h.width(), n = h.height(), r = h.scrollTop(), o = parseInt(this.element.parents().filter(function () { return "auto" !== t(this).css("z-index") }).first().css("z-index")) + 10, d = this.component ? this.component.parent().offset() : this.element.offset(), l = this.component ? this.component.outerHeight(!0) : this.element.outerHeight(!1), c = this.component ? this.component.outerWidth(!0) : this.element.outerWidth(!1), u = d.left, p = d.top; this.picker.removeClass("datepicker-orient-top datepicker-orient-bottom datepicker-orient-right datepicker-orient-left"), "auto" !== this.o.orientation.x ? (this.picker.addClass("datepicker-orient-" + this.o.orientation.x), "right" === this.o.orientation.x && (u -= e - c)) : (this.picker.addClass("datepicker-orient-left"), d.left < 0 ? u -= d.left - a : d.left + e > s && (u = s - e - a)); var f, g, v = this.o.orientation.y; "auto" === v && (f = -r + d.top - i, g = r + n - (d.top + l + i), v = Math.max(f, g) === g ? "top" : "bottom"), this.picker.addClass("datepicker-orient-" + v), "top" === v ? p += l : p -= i + parseInt(this.picker.css("padding-top")), this.picker.css({ top: p, left: u, zIndex: o }) } }, _allow_update: !0, update: function () { if (this._allow_update) { var e = this.dates.copy(), i = [], a = !1; arguments.length ? (t.each(arguments, t.proxy(function (t, e) { e instanceof Date && (e = this._local_to_utc(e)), i.push(e) }, this)), a = !0) : (i = this.isInput ? this.element.val() : this.element.data("date") || this.element.find("input").val(), i = i && this.o.multidate ? i.split(this.o.multidateSeparator) : [i], delete this.element.data().date), i = t.map(i, t.proxy(function (t) { return g.parseDate(t, this.o.format, this.o.language) }, this)), i = t.grep(i, t.proxy(function (t) { return t < this.o.startDate || t > this.o.endDate || !t }, this), !0), this.dates.replace(i), this.dates.length ? this.viewDate = new Date(this.dates.get(-1)) : this.viewDate < this.o.startDate ? this.viewDate = new Date(this.o.startDate) : this.viewDate > this.o.endDate && (this.viewDate = new Date(this.o.endDate)), a ? this.setValue() : i.length && String(e) !== String(this.dates) && this._trigger("changeDate"), !this.dates.length && e.length && this._trigger("clearDate"), this.fill() } }, fillDow: function () { var t = this.o.weekStart, e = "<tr>"; if (this.o.calendarWeeks) { var i = '<th class="cw">&nbsp;</th>'; e += i, this.picker.find(".datepicker-days thead tr:first-child").prepend(i) } for (; t < this.o.weekStart + 7;) e += '<th class="dow">' + f[this.o.language].daysMin[t++ % 7] + "</th>"; e += "</tr>", this.picker.find(".datepicker-days thead").append(e) }, fillMonths: function () { for (var t = "", e = 0; 12 > e;) t += '<span class="month">' + f[this.o.language].monthsShort[e++] + "</span>"; this.picker.find(".datepicker-months td").html(t) }, setRange: function (e) { e && e.length ? this.range = t.map(e, function (t) { return t.valueOf() }) : delete this.range, this.fill() }, getClassNames: function (e) { var i = [], a = this.viewDate.getUTCFullYear(), s = this.viewDate.getUTCMonth(), n = new Date; return e.getUTCFullYear() < a || e.getUTCFullYear() === a && e.getUTCMonth() < s ? i.push("old") : (e.getUTCFullYear() > a || e.getUTCFullYear() === a && e.getUTCMonth() > s) && i.push("new"), this.focusDate && e.valueOf() === this.focusDate.valueOf() && i.push("focused"), this.o.todayHighlight && e.getUTCFullYear() === n.getFullYear() && e.getUTCMonth() === n.getMonth() && e.getUTCDate() === n.getDate() && i.push("today"), -1 !== this.dates.contains(e) && i.push("active"), (e.valueOf() < this.o.startDate || e.valueOf() > this.o.endDate || -1 !== t.inArray(e.getUTCDay(), this.o.daysOfWeekDisabled)) && i.push("disabled"), this.range && (e > this.range[0] && e < this.range[this.range.length - 1] && i.push("range"), -1 !== t.inArray(e.valueOf(), this.range) && i.push("selected")), i }, fill: function () { var a, s = new Date(this.viewDate), n = s.getUTCFullYear(), r = s.getUTCMonth(), h = this.o.startDate !== -1 / 0 ? this.o.startDate.getUTCFullYear() : -1 / 0, o = this.o.startDate !== -1 / 0 ? this.o.startDate.getUTCMonth() : -1 / 0, d = 1 / 0 !== this.o.endDate ? this.o.endDate.getUTCFullYear() : 1 / 0, l = 1 / 0 !== this.o.endDate ? this.o.endDate.getUTCMonth() : 1 / 0, c = f[this.o.language].today || f.en.today || "", u = f[this.o.language].clear || f.en.clear || ""; this.picker.find(".datepicker-days thead th.datepicker-switch").text(f[this.o.language].months[r] + " " + n), this.picker.find("tfoot th.today").text(c).toggle(this.o.todayBtn !== !1), this.picker.find("tfoot th.clear").text(u).toggle(this.o.clearBtn !== !1), this.updateNavArrows(), this.fillMonths(); var p = i(n, r - 1, 28), v = g.getDaysInMonth(p.getUTCFullYear(), p.getUTCMonth()); p.setUTCDate(v), p.setUTCDate(v - (p.getUTCDay() - this.o.weekStart + 7) % 7); var D = new Date(p); D.setUTCDate(D.getUTCDate() + 42), D = D.valueOf(); for (var m, y = []; p.valueOf() < D;) { if (p.getUTCDay() === this.o.weekStart && (y.push("<tr>"), this.o.calendarWeeks)) { var w = new Date(+p + (this.o.weekStart - p.getUTCDay() - 7) % 7 * 864e5), k = new Date(Number(w) + (11 - w.getUTCDay()) % 7 * 864e5), _ = new Date(Number(_ = i(k.getUTCFullYear(), 0, 1)) + (11 - _.getUTCDay()) % 7 * 864e5), C = (k - _) / 864e5 / 7 + 1; y.push('<td class="cw">' + C + "</td>") } if (m = this.getClassNames(p), m.push("day"), this.o.beforeShowDay !== t.noop) { var T = this.o.beforeShowDay(this._utc_to_local(p)); T === e ? T = {} : "boolean" == typeof T ? T = { enabled: T } : "string" == typeof T && (T = { classes: T }), T.enabled === !1 && m.push("disabled"), T.classes && (m = m.concat(T.classes.split(/\s+/))), T.tooltip && (a = T.tooltip) } m = t.unique(m), y.push('<td class="' + m.join(" ") + '"' + (a ? ' title="' + a + '"' : "") + ">" + p.getUTCDate() + "</td>"), p.getUTCDay() === this.o.weekEnd && y.push("</tr>"), p.setUTCDate(p.getUTCDate() + 1) } this.picker.find(".datepicker-days tbody").empty().append(y.join("")); var b = this.picker.find(".datepicker-months").find("th:eq(1)").text(n).end().find("span").removeClass("active"); t.each(this.dates, function (t, e) { e.getUTCFullYear() === n && b.eq(e.getUTCMonth()).addClass("active") }), (h > n || n > d) && b.addClass("disabled"), n === h && b.slice(0, o).addClass("disabled"), n === d && b.slice(l + 1).addClass("disabled"), y = "", n = 10 * parseInt(n / 10, 10); var U = this.picker.find(".datepicker-years").find("th:eq(1)").text(n + "-" + (n + 9)).end().find("td"); n -= 1; for (var M, x = t.map(this.dates, function (t) { return t.getUTCFullYear() }), S = -1; 11 > S; S++) M = ["year"], -1 === S ? M.push("old") : 10 === S && M.push("new"), -1 !== t.inArray(n, x) && M.push("active"), (h > n || n > d) && M.push("disabled"), y += '<span class="' + M.join(" ") + '">' + n + "</span>", n += 1; U.html(y) }, updateNavArrows: function () { if (this._allow_update) { var t = new Date(this.viewDate), e = t.getUTCFullYear(), i = t.getUTCMonth(); switch (this.viewMode) { case 0: this.o.startDate !== -1 / 0 && e <= this.o.startDate.getUTCFullYear() && i <= this.o.startDate.getUTCMonth() ? this.picker.find(".prev").css({ visibility: "hidden" }) : this.picker.find(".prev").css({ visibility: "visible" }), 1 / 0 !== this.o.endDate && e >= this.o.endDate.getUTCFullYear() && i >= this.o.endDate.getUTCMonth() ? this.picker.find(".next").css({ visibility: "hidden" }) : this.picker.find(".next").css({ visibility: "visible" }); break; case 1: case 2: this.o.startDate !== -1 / 0 && e <= this.o.startDate.getUTCFullYear() ? this.picker.find(".prev").css({ visibility: "hidden" }) : this.picker.find(".prev").css({ visibility: "visible" }), 1 / 0 !== this.o.endDate && e >= this.o.endDate.getUTCFullYear() ? this.picker.find(".next").css({ visibility: "hidden" }) : this.picker.find(".next").css({ visibility: "visible" }) } } }, click: function (e) { e.preventDefault(); var a, s, n, r = t(e.target).closest("span, td, th"); if (1 === r.length) switch (r[0].nodeName.toLowerCase()) { case "th": switch (r[0].className) { case "datepicker-switch": this.showMode(1); break; case "prev": case "next": var h = g.modes[this.viewMode].navStep * ("prev" === r[0].className ? -1 : 1); switch (this.viewMode) { case 0: this.viewDate = this.moveMonth(this.viewDate, h), this._trigger("changeMonth", this.viewDate); break; case 1: case 2: this.viewDate = this.moveYear(this.viewDate, h), 1 === this.viewMode && this._trigger("changeYear", this.viewDate) } this.fill(); break; case "today": var o = new Date; o = i(o.getFullYear(), o.getMonth(), o.getDate(), 0, 0, 0), this.showMode(-2); var d = "linked" === this.o.todayBtn ? null : "view"; this._setDate(o, d); break; case "clear": var l; this.isInput ? l = this.element : this.component && (l = this.element.find("input")), l && l.val("").change(), this.update(), this._trigger("changeDate"), this.o.autoclose && this.hide() } break; case "span": r.is(".disabled") || (this.viewDate.setUTCDate(1), r.is(".month") ? (n = 1, s = r.parent().find("span").index(r), a = this.viewDate.getUTCFullYear(), this.viewDate.setUTCMonth(s), this._trigger("changeMonth", this.viewDate), 1 === this.o.minViewMode && this._setDate(i(a, s, n))) : (n = 1, s = 0, a = parseInt(r.text(), 10) || 0, this.viewDate.setUTCFullYear(a), this._trigger("changeYear", this.viewDate), 2 === this.o.minViewMode && this._setDate(i(a, s, n))), this.showMode(-1), this.fill()); break; case "td": r.is(".day") && !r.is(".disabled") && (n = parseInt(r.text(), 10) || 1, a = this.viewDate.getUTCFullYear(), s = this.viewDate.getUTCMonth(), r.is(".old") ? 0 === s ? (s = 11, a -= 1) : s -= 1 : r.is(".new") && (11 === s ? (s = 0, a += 1) : s += 1), this._setDate(i(a, s, n))) } this.picker.is(":visible") && this._focused_from && t(this._focused_from).focus(), delete this._focused_from }, _toggle_multidate: function (t) { var e = this.dates.contains(t); if (t ? -1 !== e ? this.dates.remove(e) : this.dates.push(t) : this.dates.clear(), "number" == typeof this.o.multidate) for (; this.dates.length > this.o.multidate;) this.dates.remove(0) }, _setDate: function (t, e) { e && "date" !== e || this._toggle_multidate(t && new Date(t)), e && "view" !== e || (this.viewDate = t && new Date(t)), this.fill(), this.setValue(), this._trigger("changeDate"); var i; this.isInput ? i = this.element : this.component && (i = this.element.find("input")), i && i.change(), !this.o.autoclose || e && "date" !== e || this.hide() }, moveMonth: function (t, i) { if (!t) return e; if (!i) return t; var a, s, n = new Date(t.valueOf()), r = n.getUTCDate(), h = n.getUTCMonth(), o = Math.abs(i); if (i = i > 0 ? 1 : -1, 1 === o) s = -1 === i ? function () { return n.getUTCMonth() === h } : function () { return n.getUTCMonth() !== a }, a = h + i, n.setUTCMonth(a), (0 > a || a > 11) && (a = (a + 12) % 12); else { for (var d = 0; o > d; d++) n = this.moveMonth(n, i); a = n.getUTCMonth(), n.setUTCDate(r), s = function () { return a !== n.getUTCMonth() } } for (; s() ;) n.setUTCDate(--r), n.setUTCMonth(a); return n }, moveYear: function (t, e) { return this.moveMonth(t, 12 * e) }, dateWithinRange: function (t) { return t >= this.o.startDate && t <= this.o.endDate }, keydown: function (t) { if (this.picker.is(":not(:visible)")) return 27 === t.keyCode && this.show(), void 0; var e, i, s, n = !1, r = this.focusDate || this.viewDate; switch (t.keyCode) { case 27: this.focusDate ? (this.focusDate = null, this.viewDate = this.dates.get(-1) || this.viewDate, this.fill()) : this.hide(), t.preventDefault(); break; case 37: case 39: if (!this.o.keyboardNavigation) break; e = 37 === t.keyCode ? -1 : 1, t.ctrlKey ? (i = this.moveYear(this.dates.get(-1) || a(), e), s = this.moveYear(r, e), this._trigger("changeYear", this.viewDate)) : t.shiftKey ? (i = this.moveMonth(this.dates.get(-1) || a(), e), s = this.moveMonth(r, e), this._trigger("changeMonth", this.viewDate)) : (i = new Date(this.dates.get(-1) || a()), i.setUTCDate(i.getUTCDate() + e), s = new Date(r), s.setUTCDate(r.getUTCDate() + e)), this.dateWithinRange(i) && (this.focusDate = this.viewDate = s, this.setValue(), this.fill(), t.preventDefault()); break; case 38: case 40: if (!this.o.keyboardNavigation) break; e = 38 === t.keyCode ? -1 : 1, t.ctrlKey ? (i = this.moveYear(this.dates.get(-1) || a(), e), s = this.moveYear(r, e), this._trigger("changeYear", this.viewDate)) : t.shiftKey ? (i = this.moveMonth(this.dates.get(-1) || a(), e), s = this.moveMonth(r, e), this._trigger("changeMonth", this.viewDate)) : (i = new Date(this.dates.get(-1) || a()), i.setUTCDate(i.getUTCDate() + 7 * e), s = new Date(r), s.setUTCDate(r.getUTCDate() + 7 * e)), this.dateWithinRange(i) && (this.focusDate = this.viewDate = s, this.setValue(), this.fill(), t.preventDefault()); break; case 32: break; case 13: r = this.focusDate || this.dates.get(-1) || this.viewDate, this._toggle_multidate(r), n = !0, this.focusDate = null, this.viewDate = this.dates.get(-1) || this.viewDate, this.setValue(), this.fill(), this.picker.is(":visible") && (t.preventDefault(), this.o.autoclose && this.hide()); break; case 9: this.focusDate = null, this.viewDate = this.dates.get(-1) || this.viewDate, this.fill(), this.hide() } if (n) { this.dates.length ? this._trigger("changeDate") : this._trigger("clearDate"); var h; this.isInput ? h = this.element : this.component && (h = this.element.find("input")), h && h.change() } }, showMode: function (t) { t && (this.viewMode = Math.max(this.o.minViewMode, Math.min(2, this.viewMode + t))), this.picker.find(">div").hide().filter(".datepicker-" + g.modes[this.viewMode].clsName).css("display", "block"), this.updateNavArrows() } }; var l = function (e, i) { this.element = t(e), this.inputs = t.map(i.inputs, function (t) { return t.jquery ? t[0] : t }), delete i.inputs, t(this.inputs).datepicker(i).bind("changeDate", t.proxy(this.dateUpdated, this)), this.pickers = t.map(this.inputs, function (e) { return t(e).data("datepicker") }), this.updateDates() }; l.prototype = { updateDates: function () { this.dates = t.map(this.pickers, function (t) { return t.getUTCDate() }), this.updateRanges() }, updateRanges: function () { var e = t.map(this.dates, function (t) { return t.valueOf() }); t.each(this.pickers, function (t, i) { i.setRange(e) }) }, dateUpdated: function (e) { if (!this.updating) { this.updating = !0; var i = t(e.target).data("datepicker"), a = i.getUTCDate(), s = t.inArray(e.target, this.inputs), n = this.inputs.length; if (-1 !== s) { if (t.each(this.pickers, function (t, e) { e.getUTCDate() || e.setUTCDate(a) }), a < this.dates[s]) for (; s >= 0 && a < this.dates[s];) this.pickers[s--].setUTCDate(a); else if (a > this.dates[s]) for (; n > s && a > this.dates[s];) this.pickers[s++].setUTCDate(a); this.updateDates(), delete this.updating } } }, remove: function () { t.map(this.pickers, function (t) { t.remove() }), delete this.element.data().datepicker } }; var c = t.fn.datepicker; t.fn.datepicker = function (i) { var a = Array.apply(null, arguments); a.shift(); var s; return this.each(function () { var h = t(this), o = h.data("datepicker"), c = "object" == typeof i && i; if (!o) { var p = n(this, "date"), f = t.extend({}, u, p, c), g = r(f.language), v = t.extend({}, u, g, p, c); if (h.is(".input-daterange") || v.inputs) { var D = { inputs: v.inputs || h.find("input").toArray() }; h.data("datepicker", o = new l(this, t.extend(v, D))) } else h.data("datepicker", o = new d(this, v)) } return "string" == typeof i && "function" == typeof o[i] && (s = o[i].apply(o, a), s !== e) ? !1 : void 0 }), s !== e ? s : this }; var u = t.fn.datepicker.defaults = { autoclose: 1, beforeShowDay: t.noop, calendarWeeks: !1, clearBtn: !1, daysOfWeekDisabled: [], endDate: 1 / 0, forceParse: !0, format: "dd/mm/yyyy", keyboardNavigation: !0, language: "en", minViewMode: 0, multidate: !1, multidateSeparator: ",", orientation: "auto", rtl: !1, startDate: -1 / 0, startView: 0, todayBtn: !1, todayHighlight: !1, weekStart: 0 }, p = t.fn.datepicker.locale_opts = ["format", "rtl", "weekStart"]; t.fn.datepicker.Constructor = d; var f = t.fn.datepicker.dates = { en: { days: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"], daysShort: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"], daysMin: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"], months: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"], monthsShort: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"], today: "Today", clear: "Clear" } }, g = { modes: [{ clsName: "days", navFnc: "Month", navStep: 1 }, { clsName: "months", navFnc: "FullYear", navStep: 1 }, { clsName: "years", navFnc: "FullYear", navStep: 10 }], isLeapYear: function (t) { return t % 4 === 0 && t % 100 !== 0 || t % 400 === 0 }, getDaysInMonth: function (t, e) { return [31, g.isLeapYear(t) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][e] }, validParts: /dd?|DD?|mm?|MM?|yy(?:yy)?/g, nonpunctuation: /[^ -\/:-@\[\u3400-\u9fff-`{-~\t\n\r]+/g, parseFormat: function (t) { var e = t.replace(this.validParts, "\x00").split("\x00"), i = t.match(this.validParts); if (!e || !e.length || !i || 0 === i.length) throw new Error("Invalid date format."); return { separators: e, parts: i } }, parseDate: function (a, s, n) { function r() { var t = this.slice(0, u[l].length), e = u[l].slice(0, t.length); return t === e } if (!a) return e; if (a instanceof Date) return a; "string" == typeof s && (s = g.parseFormat(s)); var h, o, l, c = /([\-+]\d+)([dmwy])/, u = a.match(/([\-+]\d+)([dmwy])/g); if (/^[\-+]\d+[dmwy]([\s,]+[\-+]\d+[dmwy])*$/.test(a)) { for (a = new Date, l = 0; l < u.length; l++) switch (h = c.exec(u[l]), o = parseInt(h[1]), h[2]) { case "d": a.setUTCDate(a.getUTCDate() + o); break; case "m": a = d.prototype.moveMonth.call(d.prototype, a, o); break; case "w": a.setUTCDate(a.getUTCDate() + 7 * o); break; case "y": a = d.prototype.moveYear.call(d.prototype, a, o) } return i(a.getUTCFullYear(), a.getUTCMonth(), a.getUTCDate(), 0, 0, 0) } u = a && a.match(this.nonpunctuation) || [], a = new Date; var p, v, D = {}, m = ["yyyy", "yy", "M", "MM", "m", "mm", "d", "dd"], y = { yyyy: function (t, e) { return t.setUTCFullYear(e) }, yy: function (t, e) { return t.setUTCFullYear(2e3 + e) }, m: function (t, e) { if (isNaN(t)) return t; for (e -= 1; 0 > e;) e += 12; for (e %= 12, t.setUTCMonth(e) ; t.getUTCMonth() !== e;) t.setUTCDate(t.getUTCDate() - 1); return t }, d: function (t, e) { return t.setUTCDate(e) } }; y.M = y.MM = y.mm = y.m, y.dd = y.d, a = i(a.getFullYear(), a.getMonth(), a.getDate(), 0, 0, 0); var w = s.parts.slice(); if (u.length !== w.length && (w = t(w).filter(function (e, i) { return -1 !== t.inArray(i, m) }).toArray()), u.length === w.length) { var k; for (l = 0, k = w.length; k > l; l++) { if (p = parseInt(u[l], 10), h = w[l], isNaN(p)) switch (h) { case "MM": v = t(f[n].months).filter(r), p = t.inArray(v[0], f[n].months) + 1; break; case "M": v = t(f[n].monthsShort).filter(r), p = t.inArray(v[0], f[n].monthsShort) + 1 } D[h] = p } var _, C; for (l = 0; l < m.length; l++) C = m[l], C in D && !isNaN(D[C]) && (_ = new Date(a), y[C](_, D[C]), isNaN(_) || (a = _)) } return a }, formatDate: function (e, i, a) { if (!e) return ""; "string" == typeof i && (i = g.parseFormat(i)); var s = { d: e.getUTCDate(), D: f[a].daysShort[e.getUTCDay()], DD: f[a].days[e.getUTCDay()], m: e.getUTCMonth() + 1, M: f[a].monthsShort[e.getUTCMonth()], MM: f[a].months[e.getUTCMonth()], yy: e.getUTCFullYear().toString().substring(2), yyyy: e.getUTCFullYear() }; s.dd = (s.d < 10 ? "0" : "") + s.d, s.mm = (s.m < 10 ? "0" : "") + s.m, e = []; for (var n = t.extend([], i.separators), r = 0, h = i.parts.length; h >= r; r++) n.length && e.push(n.shift()), e.push(s[i.parts[r]]); return e.join("") }, headTemplate: '<thead><tr><th class="prev">&laquo;</th><th colspan="5" class="datepicker-switch"></th><th class="next">&raquo;</th></tr></thead>', contTemplate: '<tbody><tr><td colspan="7"></td></tr></tbody>', footTemplate: '<tfoot><tr><th colspan="7" class="today"></th></tr><tr><th colspan="7" class="clear"></th></tr></tfoot>' }; g.template = '<div class="datepicker"><div class="datepicker-days"><table class=" table-condensed">' + g.headTemplate + "<tbody></tbody>" + g.footTemplate + '</table></div><div class="datepicker-months"><table class="table-condensed">' + g.headTemplate + g.contTemplate + g.footTemplate + '</table></div><div class="datepicker-years"><table class="table-condensed">' + g.headTemplate + g.contTemplate + g.footTemplate + "</table></div></div>", t.fn.datepicker.DPGlobal = g, t.fn.datepicker.noConflict = function () { return t.fn.datepicker = c, this }, t(document).on("focus.datepicker.data-api click.datepicker.data-api", '[data-provide="datepicker"]', function (e) { var i = t(this); i.data("datepicker") || (e.preventDefault(), i.datepicker("show")) }), t(function () { t('[data-provide="datepicker-inline"]').datepicker() }) }(window.jQuery);
var e = jQuery.noConflict();
e(document).ready(function () {
    e("#<%= datepicker1.ClientID %>, #datepicker2").datepicker({
        changeMonth: true,
        changeYear: true
    });
});
var e = jQuery.noConflict();
e(document).ready(function () {
    e("#<%= datepicker2.ClientID %>, #datepicker3").datepicker({
        changeMonth: true,
        changeYear: true
    });
});
var e = jQuery.noConflict();
e(document).ready(function () {
    e("#<%= Txtccdate.ClientID %>, #datepicker4").datepicker({
        changeMonth: true,
        changeYear: true
    });
});
var e = jQuery.noConflict();
e(document).ready(function () {
    e("#<%=  Txtgdate.ClientID %>, #datepicker5").datepicker({
        changeMonth: true,
        changeYear: true
    });
});
var e = jQuery.noConflict();
e(document).ready(function () {
    var currDate = new Date();
    e("#<%=  datepicker.ClientID %>, #datepicker5").datepicker({
        changeMonth: true,
        changeYear: true
    });
});
var e = jQuery.noConflict();
e(document).ready(function () {
    e("#<%=  txtend.ClientID %>, #datepicker5").datepicker({
        changeMonth: true,
        changeYear: true
    });
});

var e = jQuery.noConflict();
e(document).ready(function () {
    e("#<%=ContainerAR_txtDob.ClientID %>, #datepicker6").datepicker({
        changeMonth: true,
        changeYear: true
    });
});

// ******************************
//
// 		Textarea Auto Size
//
// ******************************
var $ = jQuery.noConflict();
$(function () {
    $('.normal').autosize();
    $('.animated').autosize();
});

(function (factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define(['jquery'], factory);
    } else {
        // Browser globals: jQuery or jQuery-like library, such as Zepto
        factory(window.jQuery || window.$);
    }
}(function ($) {
    var
	defaults = {
	    className: 'autosizejs',
	    append: '',
	    callback: false,
	    resizeDelay: 10
	},

	// border:0 is unnecessary, but avoids a bug in FireFox on OSX
	copy = '<textarea tabindex="-1" style="position:absolute; top:-999px; left:0; right:auto; bottom:auto; border:0; padding: 0; -moz-box-sizing:content-box; -webkit-box-sizing:content-box; box-sizing:content-box; word-wrap:break-word; height:0 !important; min-height:0 !important; overflow:hidden; transition:none; -webkit-transition:none; -moz-transition:none;"/>',

	// line-height is conditionally included because IE7/IE8/old Opera do not return the correct value.
	typographyStyles = [
		'fontFamily',
		'fontSize',
		'fontWeight',
		'fontStyle',
		'letterSpacing',
		'textTransform',
		'wordSpacing',
		'textIndent'
	],

	// to keep track which textarea is being mirrored when adjust() is called.
	mirrored,

	// the mirror element, which is used to calculate what size the mirrored element should be.
	mirror = $(copy).data('autosize', true)[0];

    // test that line-height can be accurately copied.
    mirror.style.lineHeight = '99px';
    if ($(mirror).css('lineHeight') === '99px') {
        typographyStyles.push('lineHeight');
    }
    mirror.style.lineHeight = '';

    $.fn.autosize = function (options) {
        if (!this.length) {
            return this;
        }

        options = $.extend({}, defaults, options || {});

        if (mirror.parentNode !== document.body) {
            $(document.body).append(mirror);
        }

        return this.each(function () {
            var
			ta = this,
			$ta = $(ta),
			maxHeight,
			minHeight,
			boxOffset = 0,
			callback = $.isFunction(options.callback),
			originalStyles = {
			    height: ta.style.height,
			    overflow: ta.style.overflow,
			    overflowY: ta.style.overflowY,
			    wordWrap: ta.style.wordWrap,
			    resize: ta.style.resize
			},
			timeout,
			width = $ta.width();

            if ($ta.data('autosize')) {
                // exit if autosize has already been applied, or if the textarea is the mirror element.
                return;
            }
            $ta.data('autosize', true);

            if ($ta.css('box-sizing') === 'border-box' || $ta.css('-moz-box-sizing') === 'border-box' || $ta.css('-webkit-box-sizing') === 'border-box') {
                boxOffset = $ta.outerHeight() - $ta.height();
            }

            // IE8 and lower return 'auto', which parses to NaN, if no min-height is set.
            minHeight = Math.max(parseInt($ta.css('minHeight'), 10) - boxOffset || 0, $ta.height());

            $ta.css({
                overflow: 'hidden',
                overflowY: 'hidden',
                wordWrap: 'break-word', // horizontal overflow is hidden, so break-word is necessary for handling words longer than the textarea width
                resize: ($ta.css('resize') === 'none' || $ta.css('resize') === 'vertical') ? 'none' : 'horizontal'
            });

            // The mirror width must exactly match the textarea width, so using getBoundingClientRect because it doesn't round the sub-pixel value.
            function setWidth() {
                var style, width;

                if ('getComputedStyle' in window) {
                    style = window.getComputedStyle(ta);
                    width = ta.getBoundingClientRect().width;

                    $.each(['paddingLeft', 'paddingRight', 'borderLeftWidth', 'borderRightWidth'], function (i, val) {
                        width -= parseInt(style[val], 10);
                    });

                    mirror.style.width = width + 'px';
                }
                else {
                    // window.getComputedStyle, getBoundingClientRect returning a width are unsupported and unneeded in IE8 and lower.
                    mirror.style.width = Math.max($ta.width(), 0) + 'px';
                }
            }

            function initMirror() {
                var styles = {};

                mirrored = ta;
                mirror.className = options.className;
                maxHeight = parseInt($ta.css('maxHeight'), 10);

                // mirror is a duplicate textarea located off-screen that
                // is automatically updated to contain the same text as the
                // original textarea.  mirror always has a height of 0.
                // This gives a cross-browser supported way getting the actual
                // height of the text, through the scrollTop property.
                $.each(typographyStyles, function (i, val) {
                    styles[val] = $ta.css(val);
                });
                $(mirror).css(styles);

                setWidth();

                // Chrome-specific fix:
                // When the textarea y-overflow is hidden, Chrome doesn't reflow the text to account for the space
                // made available by removing the scrollbar. This workaround triggers the reflow for Chrome.
                if (window.chrome) {
                    var width = ta.style.width;
                    ta.style.width = '0px';
                    var ignore = ta.offsetWidth;
                    ta.style.width = width;
                }
            }

            // Using mainly bare JS in this function because it is going
            // to fire very often while typing, and needs to very efficient.
            function adjust() {
                var height, original;

                if (mirrored !== ta) {
                    initMirror();
                } else {
                    setWidth();
                }

                mirror.value = ta.value + options.append;
                mirror.style.overflowY = ta.style.overflowY;
                original = parseInt(ta.style.height, 10);

                // Setting scrollTop to zero is needed in IE8 and lower for the next step to be accurately applied
                mirror.scrollTop = 0;

                mirror.scrollTop = 9e4;

                // Using scrollTop rather than scrollHeight because scrollHeight is non-standard and includes padding.
                height = mirror.scrollTop;

                if (maxHeight && height > maxHeight) {
                    ta.style.overflowY = 'scroll';
                    height = maxHeight;
                } else {
                    ta.style.overflowY = 'hidden';
                    if (height < minHeight) {
                        height = minHeight;
                    }
                }

                height += boxOffset;

                if (original !== height) {
                    ta.style.height = height + 'px';
                    if (callback) {
                        options.callback.call(ta, ta);
                    }
                }
            }

            function resize() {
                clearTimeout(timeout);
                timeout = setTimeout(function () {
                    var newWidth = $ta.width();

                    if (newWidth !== width) {
                        width = newWidth;
                        adjust();
                    }
                }, parseInt(options.resizeDelay, 10));
            }

            if ('onpropertychange' in ta) {
                if ('oninput' in ta) {
                    // Detects IE9.  IE9 does not fire onpropertychange or oninput for deletions,
                    // so binding to onkeyup to catch most of those occasions.  There is no way that I
                    // know of to detect something like 'cut' in IE9.
                    $ta.on('input.autosize keyup.autosize', adjust);
                } else {
                    // IE7 / IE8
                    $ta.on('propertychange.autosize', function () {
                        if (event.propertyName === 'value') {
                            adjust();
                        }
                    });
                }
            } else {
                // Modern Browsers
                $ta.on('input.autosize', adjust);
            }

            // Set options.resizeDelay to false if using fixed-width textarea elements.
            // Uses a timeout and width check to reduce the amount of times adjust needs to be called after window resize.

            if (options.resizeDelay !== false) {
                $(window).on('resize.autosize', resize);
            }

            // Event for manual triggering if needed.
            // Should only be needed when the value of the textarea is changed through JavaScript rather than user input.
            $ta.on('autosize.resize', adjust);

            // Event for manual triggering that also forces the styles to update as well.
            // Should only be needed if one of typography styles of the textarea change, and the textarea is already the target of the adjust method.
            $ta.on('autosize.resizeIncludeStyle', function () {
                mirrored = null;
                adjust();
            });

            $ta.on('autosize.destroy', function () {
                mirrored = null;
                clearTimeout(timeout);
                $(window).off('resize', resize);
                $ta
					.off('autosize')
					.off('.autosize')
					.css(originalStyles)
					.removeData('autosize');
            });

            // Call adjust in case the textarea already contains text.
            adjust();
        });
    };
}));



// ******************************
//
// 		checkbox validate
//
// ******************************

function ValidateAgeList(source, args) {
    var chkListModules = document.getElementById('<%= chkBxLstAge.ClientID %>');
    var chkListinputs = chkListModules.getElementsByTagName("input");
    for (var i = 0; i < chkListinputs.length; i++) {
        if (chkListinputs[i].checked) {
            args.IsValid = true;
            return;
        }
    }
    args.IsValid = false;
}
function ValidateTypeList(source, args) {
    var chkListModules = document.getElementById('<%= chkAgencyType.ClientID %>');
    var chkListinputs = chkListModules.getElementsByTagName("input");
    for (var i = 0; i < chkListinputs.length; i++) {
        if (chkListinputs[i].checked) {
            args.IsValid = true;
            return;
        }
    }
    args.IsValid = false;
}
$(document).ready(function () {

    $(':checkbox').change(function () {
        ValidatorValidate($("#<%= cvmodulelist.ClientID %>")[0]);
        ValidatorValidate($("#<%= CustomValidatorType.ClientID %>")[0]);
    });
});


