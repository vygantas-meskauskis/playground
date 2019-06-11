import React, { useState } from 'react';
import {uploadFinanceData} from './api/financeApi';
import { Button, Form } from 'react-bootstrap';

class FileSelector extends React.Component {

    constructor(props) {
        super(props);
        this.state = { file: {} };
      }

    onFileUpload = (event) => {
        this.setState({file: event.target.files[0] });
    };
    
    async submit(e) {
        e.preventDefault();
        uploadFinanceData(this.state.file);
        this.setState({file: {}});
      }

    render (){
        return (
            <div className="row">
                <div className="mb-4 col-lg-8">
                    <div className="mb-4 card card-small">
                        <div>
                            <h6>Upload Data</h6>
                        </div>
                        <form onSubmit={e => this.submit(e)}>
                            <input className="form-control" type="file" onChange={(event) => this.onFileUpload(event)} />
                            <Button type="submit" variant="btn-primary">Primary</Button>
                        </form>
                    </div>
                    
                </div>
            </div>
        )
    }
}

export default FileSelector;