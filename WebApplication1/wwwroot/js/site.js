// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let iconCenter;
function selectGeotag(event, polygonId, path) {
    event.preventDefault();
    event.stopPropagation();
    var polygon = document.getElementById(polygonId);
    if (polygon) {
        polygon.setAttribute("points", path);
    }
}


//function findOptimalCenter(points, learningRate = 0.1, maxIterations = 100) {
function findOptimalCenter(points) {

    if (!points || points.length === 0) {
        return null;
    }

    // 1. Инициализация начальной точки
    let currentCenter = { x: 0, y: 0 };
    for (const point of points) {
        currentCenter.x += point.x;
        currentCenter.y += point.y;
        console.log("Коордиинаты поставленных точек:", currentCenter.x, currentCenter.y)
    }
    currentCenter.x /= points.length;
    currentCenter.y /= points.length;

    // 2. Градиентный спуск
    //for (let i = 0; i < maxIterations; i++) {
    //    let gradientX = 0;
   //     let gradientY = 0;

   //    for (const point of points) {
   //         const dx = currentCenter.x - point.x;
   //         const dy = currentCenter.y - point.y;
    //        const distance = Math.sqrt(dx * dx + dy * dy);

   //         if (distance > 0) {
   //             gradientX += dx / distance;
   //             gradientY += dy / distance;
   //         }
   //     }

  //      currentCenter.x -= learningRate * gradientX;
  //      currentCenter.y -= learningRate * gradientY;
  //  }

    return currentCenter;
}

draw();
function draw() {
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
            console.log(array);
            var value = build(points);
            path.setAttribute("value", value);
            polygon.setAttribute("points", value);
            
            iconCenter = findOptimalCenter(array); // Передаем новый массив для поиска центра
            if (iconCenter) {
                console.log("Оптимальный центр полигона:", iconCenter.x, iconCenter.y);

            }
        }
    }
    function clearRender() {
        var polygon = document.getElementById("view-polygon");
        var path = document.getElementById("form-path");
        if (polygon && path) {
            var array = points.map(function (value) { return value; });
            array.push(points[0]);
            console.log(array);
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
                clearRender();
            });
        }
    });
};
// sourceMappingURL=site.js.map