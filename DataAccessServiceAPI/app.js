var express = require('express');
var logger = require('morgan');
var bodyParser = require('body-parser');

var index = require('./routes/index');
//var api = require('./routes/api.route.js')
var cors = require('cors')

var app = express();
app.use(cors())

app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));

app.use('/', index);
//app.use('/api', api);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
    var err = new Error('Not Found');
    err.status = 404;
    next(err);
  });

// error handler
  app.use(function(err, req, res, next) {
    // set locals, only providing error in development
    res.locals.message = err.message;
    res.locals.error = req.app.get('env') === 'development' ? err : {};
  
    // render the error page
    res.status(err.status || 500);
    res.send(err.message);
  });

  var bluebird = require('bluebird')


  var mongoose = require('mongoose')
  mongoose.Promise = bluebird

  const connectWithRetry = () => {
    console.log('MongoDB connection with retry')
    mongoose.connect('mongodb://mongo:27017/db', { useNewUrlParser: true })
  }
  
  mongoose.connection.on('error', err => {
    console.log(`MongoDB connection error: ${err}`)
    setTimeout(connectWithRetry, 5000)
    // process.exit(-1)
  })

  mongoose.connection.on('connected', () => {
    console.log('MongoDB is connected')
  })

  const connect = () => {
    connectWithRetry()
  }

  connect();

  app.listen(3000, ()=> {
      console.log('Server started at port 3000');
  })
  
  module.exports = app;