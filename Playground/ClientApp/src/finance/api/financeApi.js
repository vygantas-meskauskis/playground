export function uploadFinanceData(file) {
        fetch('api/FinanceData/UploadData', {
          method: 'POST',
          body: file
        }
        ).catch(
          error => console.log(error)
        );
  } 