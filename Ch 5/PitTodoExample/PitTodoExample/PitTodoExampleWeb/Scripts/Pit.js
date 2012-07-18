function registerNamespace(ns) {
    var nsParts = ns.split(".");
    var root = this;

    for (var i = 0; i < nsParts.length; i++) {
        if (typeof root[nsParts[i]] == "undefined")
            root[nsParts[i]] = {};

        root = root[nsParts[i]];
    }
}
var __hasProp = Object.prototype.hasOwnProperty, __extends = function (child, parent) {
    for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; }
    function ctor() { this.constructor = child; }
    ctor.prototype = parent.prototype;
    child.prototype = new ctor;
    child.__super__ = parent.prototype;
    return child;
};
// Object prototype extensions
// to be used for record comparisons
/*Object.prototype.ToString = function () {
    return this.toString();
}*/
registerNamespace('Pit.JsCommon');
Pit.JsCommon.equality = function (item1, item2) {
    if ((typeof (item1) == "object") && (typeof (item2) == "object")) {
        for (var key in item2) {
            var value1 = item1[key];
            var value2 = item2[key];
            if ((typeof (value1) == "object") && (typeof (value2) == "object")) {
                Pit.JsCommon.equality(value1, value2);
            }
            else {
                if (value1 !== value2) {
                    return false;
                }
            }
        }
        return true;
    }
    else {
        return item1 == item2;
    }
}
Pit.JsCommon.isInterfaceOf = function (item1, item2) {
    for (var key in item2) {
        if (typeof item1[key] == "undefined") {
            return false;
        }
    }

    return true;
}
Pit.JsCommon.containsInterface = function (item1,method) {
    return typeof item1[method] != "undefined";
}
Pit.JsCommon.invokeEvent = function (evts) {
    return function (i) {
        return function (sender) {
            return function (args) {
                return evts[i](sender, args);
            };
        };
    };
}
Pit.JsCommon.attachHandler = function (name) {
    return function (el) {
        return function (func) {
            if (el.addEventListener)
                el.addEventListener(name, func, true)
            else
                el.attachEvent("on" + name, func);
        };
    };
}
Pit.JsCommon.detachHandler = function (name) {
    return function (el) {
        return function (func) {
            if (el.removeEventListener)
                el.removeEventListener(name, func, true)
            else
                el.detachEvent("on" + name, func);
        };
    };
}
// Array prototype extensions
Array.prototype.removeAt = function (i) { this.splice(i, 1); }
Array.prototype.indexOf = function (v) { for (var i = 0; i < this.length; i++) { if (v == this[i]) return i; } return -1; }
Array.prototype.remove = function (s) { var i = this.indexOf(s); if (i != -1) this.removeAt(i); }
Array.prototype.IEnumerable1_GetEnumerator = function () {
    return Pit.FSharp.Collections.IEnumerator.ofArray(this);
}
Array.prototype.IEnumerable_GetEnumerator = function () {
    return Pit.FSharp.Collections.IEnumerator.ofArray(this);
}
Array.prototype.get_Item = function (i) {
    return this[i];
}
Array.prototype.get_Length = function () {
    return this.length;
}
String.prototype.get_Chars = function (i) {
    return this.charAt(i);
}
String.prototype.Substring = function (start, end) {
    return this.substr(start, end);
}
String.prototype.Contains = function (str) {
    return this.indexOf(str, 0) > -1;
}
String.prototype.EndsWith = function (str) {
    return this.lastIndexOf(str) > -1;
}
String.prototype.Equals = function (s) {
    return this == s;
}
String.prototype.IndexOf = function (s, pos) {
    return this.indexOf(s, pos);
}
String.prototype.get_Length = function () {
    return this.length;
}
String.prototype.LastIndexOf = function (s, pos) {
    return this.lastIndexOf(s, pos);
}
String.prototype.Replace = function (from, to) {
    var r = new RegExp(from, "g");
    return this.replace(r, to);
}
String.prototype.Split = function (sep) {
    return this.split(sep);
}
String.prototype.toLower = function () {
    return this.ToLower();
}
String.prototype.ToLower = function () {
    return this.toLowerCase();
}
String.prototype.toUpper = function () {
    return this.ToUpper();
}
String.prototype.ToUpper = function () {
    return this.toUpperCase();
}
registerNamespace('Pit.Js');
Pit.Js.DOM = (function () {
    function DOM() {
        this.isReady = false;
        this.readyBound = false;
        this.readyList = [];
        var document = window.document;
        this.DOMContentLoaded = function () {
            document.removeEventListener("DOMContentLoaded", window.DOM.DOMContentLoaded, false);
            window.DOM.ready();
        };

        if (document.attachEvent) {
            // Make sure body exists, at least, in case IE gets a little overzealous (ticket #5443).
            if (document.readyState === "complete") {
                document.detachEvent("onreadystatechange", window.DOM.DOMContentLoaded);
                window.DOM.ready();
            }
        }

        this.domReady = function (fn) {
            this.bindReady();
            if (this.isReady) {
                fn.call(document);
            }
            else if (this.readyList) {
                this.readyList.push(fn);
            }
        }

        this.ready = function () {
            if (!this.isReady) {
                if (!document.body) {
                    return setTimeout(ready, 13);
                }

                this.isReady = true;

                if (this.readyList) {
                    var fn, i = 0;
                    while ((fn = this.readyList[i++])) {
                        fn.call(document);
                    }

                    this.readyList = null;
                }
            }
        }

        this.doScrollCheck = function () {
            if (this.isReady) {
                return;
            }

            try {
                // If IE is used, use the trick by Diego Perini
                // http://javascript.nwbox.com/IEContentLoaded/
                document.documentElement.doScroll("left");
            } catch (error) {
                setTimeout(this.doScrollCheck, 1);
                return;
            }

            // and execute any waiting functions
            this.ready();
        }

        this.bindReady = function () {
            if (this.readyBound) {
                return;
            }

            this.readyBound = true;
            if (document.readyState === "complete") {
                this.ready();
            }

            if (document.addEventListener) {
                document.addEventListener("DOMContentLoaded", this.DOMContentLoaded, false);
            }
            else if (document.attachEvent) {
                document.attachEvent("onreadystatechange", this.DOMContentLoaded);
                // A fallback to window.onload, that will always work
                window.attachEvent("onload", this.ready);
                // If IE and not a frame
                // continually check to see if the document is ready
                var toplevel = false;

                try {
                    toplevel = window.frameElement == null;
                } catch (e) { }

                if (document.documentElement.doScroll && toplevel) {
                    this.doScrollCheck();
                }
            }
        }
    }

    window.DOM = new DOM();
    return DOM;
})();