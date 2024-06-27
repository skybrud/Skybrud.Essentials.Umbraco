angular.module("umbraco").directive("limboJsonView", function () {

    function render(e, value, level, array) {
        if (value === null) {
            renderNull(e, level, array);
        } else if (typeof value === "boolean") {
            renderBoolean(e, value, level, array);
        } else if (typeof value === "number") {
            renderNumber(e, value, level, array);
        } else if (typeof value === "string") {
            renderString(e, value, level, array);
        } else if (Array.isArray(value)) {
            renderArray(e, value, level, array);
        } else if (typeof value === "object") {
            renderObject(e, value, level, array);
        } else {
            // meh
        }
    }

    function renderNull(e) {

        const ee = document.createElement("span");
        ee.classList.add("json-null");
        ee.innerText = "null";
        e.appendChild(ee);

    }

    function renderBoolean(e, value) {

        const ee = document.createElement("span");
        ee.classList.add("json-boolean");
        ee.innerText = value;
        e.appendChild(ee);

    }

    function renderNumber(e, value) {

        const ee = document.createElement("span");
        ee.classList.add("json-number");
        ee.innerText = value;
        e.appendChild(ee);

    }

    function renderString(e, value) {

        const ee = document.createElement("span");
        ee.classList.add("json-string");
        ee.innerText = "\"" + value.replaceAll("\n", "\\n") + "\"";
        e.appendChild(ee);

    }

    function renderArray(e, value) {

        // If array is empty, we can add [ ] and return right away
        if (value.length == 0) {
            e.appendChild(document.createTextNode("[ ]"));
            return;
        }

        // Create the collapser element
        const ee = document.createElement("div");
        ee.classList.add("collapser");
        e.appendChild(ee);

        // Append the opening square bracket
        e.appendChild(document.createTextNode("["));

        // Append the ellipsis
        const el = document.createElement("span");
        el.classList.add("ellipsis");
        el.innerText = "...";
        e.appendChild(el);

        // Append a <ul> for the array children
        const ul = document.createElement("ul");
        ul.classList.add("array");
        ul.classList.add("collapsible");
        e.appendChild(ul);

        // Add a click event listener to the collapser
        ee.addEventListener("click", function () {
            e.classList.toggle("collapsed");
        });

        // Iterate through the items of the array
        for (let i = 0; i < value.length; i++) {

            // Add a new <li> for the array item
            const li = document.createElement("li");
            ul.appendChild(li);

            // Render the array item
            render(li, value[i]);

            // Unless the last item in the array, we need to add a comma
            if (i < value.length - 1) li.appendChild(document.createTextNode(","));

        }

        // Append the closing square bracket
        e.appendChild(document.createTextNode("]"));

    }

    function renderObject(e, value) {

        // Gets the property keys of the object
        const keys = Object.keys(value);

        // If object is empty, we can add [ ] and return right away
        if (keys.length === 0) {
            e.appendChild(document.createTextNode("{ }"));
            return;
        }

        // Create the collapser element
        const ee = document.createElement("div");
        ee.classList.add("collapser");
        e.appendChild(ee);

        // Append the opening curly bracket
        e.appendChild(document.createTextNode("{"));

        // Append the ellipsis
        const el = document.createElement("span");
        el.classList.add("ellipsis");
        el.innerText = "...";
        e.appendChild(el);

        // Append a <ul> for the object properties
        const ul = document.createElement("ul");
        ul.classList.add("obj");
        ul.classList.add("collapsible");
        e.appendChild(ul);

        // Add a click event listener to the collapser
        ee.addEventListener("click", function () {
            e.classList.toggle("collapsed");
        });

        // Iterate through the keys / properties
        keys.forEach(function (key, i) {

            // Add a new <li> for the property
            const li = document.createElement("li");
            ul.appendChild(li);

            // Append a <span> with the property name
            const pp = document.createElement("span");
            pp.classList.add("json-property");
            pp.innerText = key;
            li.appendChild(pp);

            // Append the : as well
            li.appendChild(document.createTextNode(": "))

            // Render the property value
            render(li, value[key]);

            // Unless the last key in the object, we need to add a comma
            if (i < keys.length - 1) li.appendChild(document.createTextNode(","));

        });

        // Append the closing curly bracket
        e.appendChild(document.createTextNode("}"));

    }

    return {
        restrict: "E",
        replace: true,
        scope: {
            value: '=value'
        },
        template: "<div class=\"limbo-json-view\"><umb-button type=\"button\" state=\"copyButtonState\" ng-click=\"copy()\" label=\"Copy\"></umb-button></div>",
        link: function ($scope, $element) {

            const root = $element[0];

            render(root, $scope.value);

            $scope.copy = function () {

                // We don't have the original JSON string, so
                const json = JSON.stringify($scope.value, null, "  ");

                // Copy the JSON string to the clipboard
                const type = "text/plain";
                const blob = new Blob([json], { type });
                const data = [new ClipboardItem({ [type]: blob })];
                navigator.clipboard.write(data);

                // Send a success state to the copy button
                $scope.copyButtonState = "success";

            }

        }
    };
});