var mongoose = require('mongoose');
//var mongoosePaginate = require('mongoose-paginate');

var metaScehma = new mongoose.Schema({
    targetVal : {
        type: String,
        required: true
    },
    replaceVal: {
        type: String,
        required: true,
    }
});

const Rule = mongoose.model('meta', metaScehma);

module.exports = Rule;