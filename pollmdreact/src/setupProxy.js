const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/survey",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7170',
        secure: false
    });

    app.use(appProxy);
};
