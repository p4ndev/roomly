const { env } = require('process');

const target = (
  env.ASPNETCORE_HTTPS_PORT ?
    `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    (env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7168')
);

const PROXY_CONFIG = [
  {
    context: [
      "/api",
      "/live",
    ],
    target,
    ws: true,
    secure: false,
    logLevel: 'debug',
    onProxyReq: (proxyReq, req, res) => {
      console.log(proxyReq);
      console.log(`[Proxy Request] ${req.method} ${req.url} -> ${target}`);
      console.log(res);
    },
    onError: (err, req, res) => {
      console.error(`[Proxy Error] ${req.url}`, err);
      console.log(res);
    }
  }
]

module.exports = PROXY_CONFIG;
