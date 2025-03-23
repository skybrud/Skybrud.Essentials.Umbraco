import { UmbElementMixin } from "@umbraco-cms/backoffice/element-api";
import { LitElement, html, repeat, when } from "@umbraco-cms/backoffice/external/lit";

function xmlDurationToSeconds(value) {

    const p = "(([0-9]+)(H|M|S|D)|)";

    const m = value.match(`^P${p}${p}${p}T${p}${p}${p}$`);
    if (!m) return 0;

    // Depending on whether "M" comes before or after "T", it may mean either months or minutes. Since it's very
    // unlikely that we'll encounter videos that last for months, this implementation currently doesn't check for
    // the position of the "M".

    let seconds = 0;

    for (let i = 1; i < m.length; i += 3) {
        if (m[i]) {
            switch (m[i + 2]) {
                case "D":
                    seconds += parseInt(m[i + 1]) * 24 * 60 * 60;
                    break;
                case "H":
                    seconds += parseInt(m[i + 1]) * 60 * 60;
                    break;
                case "M":
                    seconds += parseInt(m[i + 1]) * 60;
                    break;
                case "S":
                    seconds += parseInt(m[i + 1]);
                    break;
            }
        }
    }

    return seconds;

}

export class SkybrudDurationElement extends UmbElementMixin(LitElement) {

    static observedAttributes = ["value"];

    constructor() {
        super();
    }

    connectedCallback() {
        super.connectedCallback();
        this.duration = this.parse(this.getAttribute("value"));
    }

    attributeChangedCallback(name, oldValue, newValue) {
        if (name != "value") return;
        this.duration = this.parse(newValue);
        this.requestUpdate();
    }

    hest(value, singular, plural) {
        const key = "skybrud_" + (value === 1 ? singular : plural);
        return {
            value: value,
            text: this.localize.term(key),
            suffix: this.localize.term(key).substr(0, 1)
        };
    }

    parse(value) {

        let seconds;

        if (value === undefined || value === null || value === NaN) {
            seconds = null;
        } else if (typeof value === "object" && value.duration) {
            seconds = value.duration;
        } else if (typeof value === "number") {
            seconds = value;
        } else if (typeof (value) === "string") {
            if (value.length === 0) {
                seconds = null;
            } else if (value[0] === "P") {
                seconds = xmlDurationToSeconds(value);
            } else {
                seconds = parseFloat(value);
                if (isNaN(seconds)) seconds = null;
            }
        } else {
            seconds = null;
        }

        seconds = Math.floor(seconds);

        const duration = [];

        const hours = Math.floor(seconds / 60 / 60);
        seconds = seconds - (hours * 60 * 60);

        const minutes = Math.floor(seconds / 60);
        seconds = seconds - (minutes * 60);

        if (hours > 0) duration.push(this.hest(hours, "hour", "hours"));
        if (minutes > 0) duration.push(this.hest(minutes, "minute", "minutes"));
        if (seconds > 0) duration.push(this.hest(seconds, "second", "seconds"));

        if (duration.length > 1) {

            // Append "and" as a filler between the last and second last items
            duration.splice(duration.length - 1, 0, {
                text: ` ${ this.localize.term("skybrud_and")} `,
                suffix: ` ${this.localize.term("skybrud_and")} `
            });

            // Append ", " as filler between remaining items
            for (let i = 0; i < duration.length - 3; i++) {
                duration[i].text += ", ";
                duration[i].suffix += ", ";
            }

        }

        return duration;

    }

    render() {
        return html`
            <span class=\"skybrud-duration\">
                ${repeat(this.duration, (dur) => dur, (dur) => html`
                    ${dur.value} <small>${dur.text}</small>
                `)}
                ${when(this.duration.length == 0, () => html`
                    <em>${this.localize.term("skybrud_na")}</em>
                `)}
            </span>
        `;
    }

};

customElements.define("skybrud-duration", SkybrudDurationElement);

export default SkybrudDurationElement;