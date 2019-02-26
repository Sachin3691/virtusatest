var express = require('express');
var router = express.Router();

var CountryCodeController = require('../controllers/countryCode.controller');

/* GET home page. */
router.get('/', function(req, res, next) {
  res.send('Ok');
});

router.get('/all', CountryCodeController.getAll);
router.get('/insert', CountryCodeController.insert);

module.exports = router;