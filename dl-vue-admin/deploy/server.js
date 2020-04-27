const express = require('express')
const serveStatic = require('serve-static')
const app = express()

app.disable('x-powered-by')

app.use(require('connect-history-api-fallback')())

app.use((req, res, next) => {
  res.setHeader('Cache-Control', 'public,max-age=315360000s')
  next()
})

app.use(serveStatic('./dist'))

const port = 8090
app.listen(port)

console.log('server started ' + port)
