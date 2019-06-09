export function uploadFinanceData(file) {
        fetch('api/FinanceData/UploadData', {
          method: 'POST',
          headers: {
            "Content-Type": "multipart/form-data"
          },
          body: file
        }
        ).catch(
          error => console.log(error)
        );
  } 