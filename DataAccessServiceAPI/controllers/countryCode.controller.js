var CountryCodeService = require('../services/coutryCode.service');

_this = this;

exports.getAll = async function(req, res, next) {

    var countryCode = await CountryCodeService.getAll();
    return res.json({
        data: countryCode
    });
}
LogLog
exports.insert = async function(req, res, next) {
    debugger;
    await CountryCodeService.insert();
    return res.json({
        data: 'OK'
    });
}

