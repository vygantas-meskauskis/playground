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
            <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                    <th>#</th>
                    <th>Date</th>
                    <th>TransferAmount</th>
                    <th>Description</th>
                    <th>Category</th>
                    <th>Notes</th>
                    </tr>
                </thead>
                <tbody>
                    {financeData.financeRecordViewModels.map(element =>
                            <tr>
                                <td>1</td>
                                <td>{element.date}</td>
                                <td>{element.transferAmount}</td>
                                <td>{element.description}</td>
                                <td>{element.category}</td>
                                <td>{element.notes}</td>
                            </tr>
                )}
                </tbody>
            </Table>
        );
    }

render() {
  let contents;
    if (this.state.loading){
      contents = <p><em>Loading...</em></p>;
    } else if (this.state.financeData.financeReportViewModels === undefined 
      || this.state.financeData.financeReportViewModels.length == 0){
        contents = <p>no data</p>
    } else {
      contents = TableReport.renderReportTable(this.state.financeData.financeReportViewModels[0]);
    }

    return (
      <div>
        <h2>Table report</h2>
        {contents}
      </div>
    );
  }
}