function selectGeotag(event, polygonId, path) {
    event.preventDefault();
    event.stopPropagation();

    const polygon = document.getElementById(polygonId);
    if (polygon) {
        polygon.setAttribute("points", path);
    }
}

type SvgInHtml = HTMLElement & SVGElement & SVGGraphicsElement;

(function () {
    const points = [];

    function build(points: DOMPoint[]) {
        var res = [];
        for (var i = 0, l = points.length; i < l; i++) {
            res.push(`${points[i].x},${points[i].y}`);
        }
        return res.join(' ');
    }

    function editRender() {
        const polygon = document.getElementById("view-polygon");
        const path = document.getElementById("form-path");

        if (polygon && path) {
            const array = points.map((value) => value);
            array.push(points[0]);
            const value = build(points);
            path.setAttribute("value", value);
            polygon.setAttribute("points", value);
        }
    }
    
    document.addEventListener("DOMContentLoaded", () => {
        const svg: SvgInHtml = document.getElementById("map-svg") as SvgInHtml;

        if (svg) {
            svg.addEventListener("mousedown", (event) => {
                const point = new DOMPoint(event.clientX, event.clientY);
                const position = point.matrixTransform(svg.getScreenCTM().inverse())
                points.push(new DOMPoint(Math.floor(position.x), Math.floor(position.y)));
                editRender();
            });
        }

        const buttonClear = document.getElementById("clear-path");
        if (buttonClear) {
            buttonClear.addEventListener("click", (event) => {
                points.length = 0;
                editRender();
            });
        }
    });
})();