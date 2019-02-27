var mongoose = require('mongoose');
//var mongoosePaginate = require('mongoose-paginate');

var countryCodeSchema = new mongoose.Schema({
    mobileNumber: {
        type: String,
        required: true,
    },
    country: {
        type: String,
        required: true
    }
});

//countryCodeSchema.plugin(mongoosePaginate);

const Country = mongoose.model('country', countryCodeSchema);

module.exports = Country;