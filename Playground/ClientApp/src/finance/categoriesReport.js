import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import FileSelector from './FileSelector';
import {getFinanceTransactions} from './api/financeApi';

export class CategoriesReport extends Component {
    constructor(props) {
        super(props);
        this.state = { financeData: [], loading: true };
    
        // var queryParameters = sources.join(',');
        fetch('api/FinanceData/CategorizedTransactions?sources=revolut')
        .then(response => response.json())
        .then(data => {
            this.setState({financeData: data, loading: false})
        });

        // let financeTransactions = getFinanceTransactions(['revolut']);
        // this.setState({financeData: financeTransactions, loading: false}); 
      }

      static renderReportTable(financeData){
        return(
            <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                    <th>Category</th>
                    <th>Percentage</th>
                    <th>Amount</th>
                    <th>NumberOfTransactions</th>
                    </tr>
                </thead>
                <tbody>
                    {financeData.map(element =>
                            <tr>
                                <td>{element.category}</td>
                                <td>{element.percentage}</td>
                                <td>{element.amount}</td>
                                <td>{element.numberOfTransactions}</td>
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
    } else if (this.state.financeData === undefined 
      || this.state.financeData.length == 0){
        contents = <p>no data</p>
    } else {
      contents = CategoriesReport.renderReportTable(this.state.financeData);
    }

    return (
      <div>
        <h2>Table report</h2>
        {contents}
      </div>
    );
  }
}