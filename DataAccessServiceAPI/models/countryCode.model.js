var mongoose = require('mongoose');
//var mongoosePaginate = require('mongoose-paginate');

var countryCodeSchema = new mongoose.Schema({
    countryCode : {
        type: Number,
        required: true
    },
    mobileNumber: {
        type: Number,
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