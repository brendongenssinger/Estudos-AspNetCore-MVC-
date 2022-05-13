async function Check() {
    var select = document.getElementById('COD_PRODUTO');
    console.log(select);
    console.log(select.options);
    var optionSelect = select.options[select.options.selectedIndex];
    console.log(optionSelect.value);
    console.log(optionSelect.text);
    var selectorT = document.getElementById("dropDownCosif");
    console.log(selectorT.options);
    if (selectorT.options.length > 1) {
        for (var i = 1; i < selectorT.options.length; i++) {
            selectorT.removeChild(selectorT.options[i]);
        }
    }
    var result = await fetch(window.location.origin + "/Home/Get?IdProduto=" + optionSelect.value);
    if (result.ok)
    {
        document.getElementById("dropDownCosif").disabled = false;
        let result2 = await result.json();  
        console.log(result2);

        result2.forEach(function (name)
        {
            let _text = name.coD_COSIF
            var selector = document.getElementById("dropDownCosif");
            var newOption = document.createElement("option");
            newOption.textContent = name.coD_COSIF + " - " + "(" + name.coD_CLASSIFICACAO + ")";
            newOption.value = name.coD_COSIF;
            selector.add(newOption);
        });
    }
    
    

}

