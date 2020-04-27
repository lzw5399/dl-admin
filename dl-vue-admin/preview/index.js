const { run } = require('runjs')

run(`vue-cli-service build`)

run('node ./deploy/server.js')
