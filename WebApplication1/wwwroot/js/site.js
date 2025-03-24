// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function selectGeotag(event, polygonId, path) {
    event.preventDefault();
    event.stopPropagation();
    var polygon = document.getElementById(polygonId);
    if (polygon) {
        polygon.setAttribute("points", path);
    }
}
(function () {
    var points = [];
    function build(points) {
        var res = [];
        for (var i = 0, l = points.length; i < l; i++) {
            res.push("".concat(points[i].x, ",").concat(points[i].y));
        }
        return res.join(' ');
    }
    function editRender() {
        var polygon = document.getElementById("view-polygon");
        var path = document.getElementById("form-path");
        if (polygon && path) {
            var array = points.map(function (value) { return value; });
            array.push(points[0]);
            var value = build(points);
            path.setAttribute("value", value);
            polygon.setAttribute("points", value);
        }
    }
    document.addEventListener("DOMContentLoaded", function () {
        var svg = document.getElementById("map-svg");
        if (svg) {
            svg.addEventListener("mousedown", function (event) {
                var point = new DOMPoint(event.clientX, event.clientY);
                var position = point.matrixTransform(svg.getScreenCTM().inverse());
                points.push(new DOMPoint(Math.floor(position.x), Math.floor(position.y)));
                editRender();
            });
        }
        var buttonClear = document.getElementById("clear-path");
        if (buttonClear) {
            buttonClear.addEventListener("click", function (event) {
                points.length = 0;
                editRender();
            });
        }
    });
})();
//# sourceMappingURL=site.js.map