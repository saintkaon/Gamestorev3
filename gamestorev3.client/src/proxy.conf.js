const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:5097';

const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target,
    secure: false,
    changeOrigin: true, // Add this line to help handle CORS
    logLevel: 'debug' // Optional: Add this line to help with debugging
  }
]

module.exports = PROXY_CONFIG;
