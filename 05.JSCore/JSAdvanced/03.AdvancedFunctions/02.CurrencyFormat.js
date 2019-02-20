function getDollarFormatter (formatter){
    function dollarFormatter(value){
        return formatter(',', '$', true, value);
    }
    return dollarFormatter;
}