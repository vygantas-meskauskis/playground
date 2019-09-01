export function uploadFinanceData(file) {
        fetch('api/FinanceData/UploadData', {
          method: 'POST',
          body: file
        }
        ).catch(
          error => console.log(error)
        );
  } 

export function getFinanceTransactions(sources){
  var queryParameters = sources.join(',');
    return fetch('api/FinanceData/CategorizedTransactions?sources=' + queryParameters)
      .then(onSuccess, onError);
  }

function onSuccess(response){
  return response.json();
}

function onError(error){
  console.log(error);
}