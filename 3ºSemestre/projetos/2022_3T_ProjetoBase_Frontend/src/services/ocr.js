import axios from "axios";

export const LerConteudoDaImagem = async (formData) => {


    let resultado;

    await  axios({
        method : "POST",
        url : "https://OCRPedroF.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data : formData,
        headers : {
                "Content-Type" : "multipart/form/data",
                "Ocp-Apim-Subscription-Key" : "0a0c595a03254ba4a53778d476323b75"
        }

    })

    .then(response => {
        // console.log(response)
        resultado = FiltrarOBJ(response.data);
    })
    .catch(erro => console.log(erro))

    return resultado; 


}
// Serve pra certificar todas as linhas e verificar informações pertinentes
export const FiltrarOBJ = (obj) => {

    let resultado;

    obj.regions.forEach(region => {
        region.lines.forEach(line => {
            line.words.forEach(word => {
                if(word.text[0] === "1" && word.text[1] === "2"){
                    resultado = word.text;
                }
            })
        })


    });

    return resultado;
}