import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import FileSelector from './FileSelector';
import {uploadFinanceData} from './api/financeApi';

export class TableReport extends Component {
    constructor(props) {
        super(props);
        this.state = { financeData: [], loading: true };
    
        fetch('api/FinanceData/FinanceReport')
        .then(response => response.json())
        .then(data => {
            this.setState({financeData: data, loading: false})
        });  
      }

      static renderReportTable(financeData){
        return(
          {financeData.map(data => 
            
            <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                    <th>#</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Username</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(element =>
                            <tr>
                                <td>1</td>
                                <td>Mark</td>
                                <td>Otto</td>
                                <td>@mdo</td>
                            </tr>
                )}
                </tbody>
            </Table>
            )}
        );
    }

render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : TableReport.renderReportTable(this.state.financeData);

    return (
      <div>
        <h2>Table report</h2>
        {contents}
      </div>
    );
  }
}