const express = require('express')
const serveStatic = require('serve-static')
const app = express()

app.disable('x-powered-by')
app.disable('Cache-Control')

app.use(require('connect-history-api-fallback')())

app.use(serveStatic('./dist'))

const port = 80
app.listen(port)

console.log('server started ' + port)
