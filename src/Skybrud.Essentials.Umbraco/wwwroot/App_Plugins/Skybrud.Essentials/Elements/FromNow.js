import { UmbElementMixin } from "@umbraco-cms/backoffice/element-api";
import { LitElement } from "@umbraco-cms/backoffice/external/lit";

export class SkybrudFromNowElement extends UmbElementMixin(LitElement) {

    hmm(value, diff) {
        const result = diff < 0 ? value + " " + this.localize.term("skybrud_ago") : value + " " + this.localize.term("skybrud_in") + " " + value;
        return ">>" + result + "<<";
    }

    diff(date) {

        let diff = date.getTime() / 1000 - new Date().getTime() / 1000;

        let abs = Math.abs(diff);

        const days = Math.floor(abs / 60 / 60 / 24);
        if (days > 0) return this.hmm(this.localize.term("skybrud_days", days), diff);

        const hours = Math.floor(abs / 60 / 60);
        if (hours > 1) return this.hmm(this.localize.term("skybrud_hours", hours), diff);

        const minutes = Math.floor(abs / 60);
        if (minutes > 1) return this.hmm(this.localize.term("skybrud_minutes", minutes), diff);

        return this.localize.term("skybrud_now");

    }

    constructor() {
        super();
    }

    connectedCallback() {

        if (!this.textContent) return;

        try {
            console.log("Text: " + this.textContent);
            var date = new Date(this.textContent);
        } catch {
            this.textContent = "Invalid date: " + this.textContent;
        }

        this.textContent = this.diff(date);

    }

};

customElements.define("skybrud-from-now", SkybrudFromNowElement);

export default SkybrudFromNowElement;