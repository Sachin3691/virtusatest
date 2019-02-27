var Country = require('../models/countryCode.model');
ObjectID =  require("mongodb").ObjectID;

_this = this

exports.getAll = async function() {
    //insert();
   var data = await Country.find();
   return data;
}

exports.insert = async function() {
    var Num1 = new Country({
        country: "India",
        mobileNumber: "+918050033795",
    });
    var Num2 = new Country({
        country: "India",
        mobileNumber: "+918050033796",
    });

    var Num3 = new Country({
        country: "US",
        mobileNumber: "+18050033795",
    });
    await Num1.save();
    await Num2.save();
    await Num3.save();

}

exports.getCountry = async function(phoneNumbers) {

    var datat =  await Country.find({'mobileNumber' : { $in:phoneNumbers }});
    console.log(datat);

    return datat;


}