import "@skybrud-elements/duration";
import "@skybrud-elements/from-now";
import "@skybrud-elements/json";

export const onInit = (_host, extensionRegistry) => {

    extensionRegistry.register({
        "type": "localization",
        "alias": "Limbo.EnUS",
        "name": "English (United States)",
        "js": () => import('./en-US.js'),
        "meta": {
            "culture": "en-US"
        }
    });

    extensionRegistry.register({
        "type": "localization",
        "alias": "Limbo.En",
        "name": "English",
        "js": () => import('./en-US.js'),
        "meta": {
            "culture": "en"
        }
    });

    extensionRegistry.register({
        "type": "localization",
        "alias": "Limbo.DaDk",
        "name": "Danish (Denmark)",
        "js": () => import('./da-DK.js'),
        "meta": {
            "culture": "da-DK"
        }
    });

};