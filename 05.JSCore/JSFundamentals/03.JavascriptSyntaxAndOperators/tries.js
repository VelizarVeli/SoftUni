function solve (){
    console.log(foo);
    var foo = function(){
        return 'zz';
    };
}
solve();