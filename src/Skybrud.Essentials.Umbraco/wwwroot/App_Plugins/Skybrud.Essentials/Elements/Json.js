import { UmbElementMixin } from "@umbraco-cms/backoffice/element-api";
import { LitElement, html, css, repeat } from "@umbraco-cms/backoffice/external/lit";

export class SkybrudJsonElement extends UmbElementMixin(LitElement) {

    get value() {
        return this._value;
    }

    set value(v) {
        this._value = v;
        this.requestUpdate();
    }

    constructor() {
        super();
    }

    connectedCallback() {
        super.connectedCallback();
    }

    render() {
        return this.renderValue(this.value);
    }

    renderValue(value, level, array, path) {

        if (!level) level = 1;

        if (value === null) {
            return this.renderNull(level, array, path);
        } else if (typeof value === "boolean") {
            return this.renderBoolean(value, level, array, path);
        } else if (typeof value === "number") {
            return this.renderNumber(value, level, array, path);
        } else if (typeof value === "string") {
            return this.renderString(value, level, array, path);
        } else if (Array.isArray(value)) {
            return this.renderArray(value, level, array, path);
        } else if (typeof value === "object") {
            return this.renderObject(value, level, array, path);
        } else {
            return this.renderNull();
        }

    }

    renderNull() {
        return html`<span class="json-null">null</span>`;
    }

    renderBoolean(value) {
        return html`<span class="json-boolean">${value}</span>`;
    }

    renderNumber(value) {
        return html`<span class="json-number">${value}</span>`;
    }

    renderString(value) {

        const div = document.createElement("div");
        div.innerHTML = value;

        return html`<span class="json-string">"${div.innerText}"</span>`;

        //ee.classList.add("json-string");
        //ee.innerText = "\"" + value.replaceAll("\n", "\\n") + "\"";
        //e.appendChild(ee);

    }

    renderArray(value, level) {

        if (value.length === 0) {
            return html`[<span class="count">${this.localize.term("skybrud_items", value.length)}</span>]`;

        }

        const temp = [
            html`<div class="collapser" onclick="this.parentNode.classList.toggle('collapsed');"></div>`,
            "[",
            html`<span class="ellipsis">...</span>`,
            html`<span class="count">${this.localize.term("skybrud_items", value.length)}</span>`,
            html`<ul class="array collapsible">
                ${repeat(value, (item, index) => html`
                    <li>
                        ${this.renderValue(item, level + 1)}${(index < value.length - 1 ? "," : "")}
                    </li>
                `)}
            </ul>`,
            "]"
        ];

        return html`${repeat(temp, e => e)}`;

    }

    renderObject(value, level) {

        const properties = Object.keys(value).map(function (key, index) {
            return { key, index, value: value[key] }
        });

        const temp = [
            html`<div class="collapser" onclick="this.parentNode.classList.toggle('collapsed');"></div>`,
            html`{`,
            html`<span class="ellipsis">...</span>`,
            html`<span class="count">${this.localize.term("skybrud_properties", properties.length)}</span>`,
            html`<ul class="obj collapsible">
                ${repeat(properties, p => html`
                    <li>
                        <span class="json-property">${p.key}</span>:
                        ${this.renderValue(p.value, level + 1)}${(p.index < properties.length - 1 ? "," : "")}
                    </li>
                `)}
            </ul>`,
            html`}`
        ];

        return html`${repeat(temp, e => e)}`;

    }

    static styles = css`
:host {
    display: block;
    font-family: monospace;
    font-size: 11px;
    line-height: 15px;
    padding: 9.5px;
    background-color: #f6f4f4;
    border: 1px solid #d8d7d9;
    border-radius: 3px;
    position: relative;
    overflow: hidden;
  }


   .collapser {
    padding-right: 6px;
    padding-left: 6px;
    position: absolute;
    top: 0.1em;
    left: -1.4em;
    cursor: default;
  }
   .collapser:after {
    content: "-";
  }
   .json-property {
    font-weight: bold;
  }
   .json-boolean {
    color: firebrick;
  }
   .json-number {
    color: blue;
  }
   .json-string {
    color: green;
  }
   .json-null {
    color: gray;
  }
  .ellipsis {
    display: none;
    padding: 0 5px;
  }
  ul,
  li {
    list-style: none;
    margin: 0 15px;
    padding: 0;
  }
 li {
    position: relative;
  }
 .collapsed > .collapser:after {
    content: "+";
  }
 .collapsed > .collapsible {
    display: none;
  }
  .collapsed > .count {
    display: none;
  }
 .collapsed > .ellipsis {
    display: inline-block;
}

.count {
    background: #BBB;
    color: #fff;
    margin: 0 2px;
    padding: 0 3px;
    font-size: 10px;
    user-select: none;
}
    `;

};

customElements.define("skybrud-json", SkybrudJsonElement);

export default SkybrudJsonElement;