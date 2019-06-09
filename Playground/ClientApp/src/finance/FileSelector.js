import React, { useState } from 'react';
import {uploadFinanceData} from './api/financeApi';
import { Button, Form } from 'react-bootstrap';

class FileSelector extends React.Component {

    onFileUpload = (event) => {
        uploadFinanceData(event.target.files[0])
    };
    
    render (){
        return (
            <div className="row">
                <div className="mb-4 col-lg-8">
                    <div className="mb-4 card card-small">
                        <div>
                            <h6>Upload Data</h6>
                        </div>
                        <input className="form-control" type="file" onChange={(event) => this.onFileUpload(event)} />
                        <Button variant="btn-primary">Primary</Button>
                    </div>
                    
                </div>
            </div>
        )
    }
}

export default FileSelector;