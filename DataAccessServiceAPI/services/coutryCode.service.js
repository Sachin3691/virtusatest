var Country = require('../models/countryCode.model');
ObjectID =  require("mongodb").ObjectID;

_this = this

exports.getAll = async function() {
    //insert();
   var data = await Country.find();
   return data;
}

insert = async function() {
    var India = new Country({
        country: "India",
        mobileNumber: 8050033795,
        countryCode: "+91"
    
    });

    var data = await India.save();
}
