import React, { useState } from 'react';
import { Tab, Tabs } from 'react-bootstrap';
import FileSelector from './FileSelector';
import { TableReport } from './TableReport';
import { CategoriesReport } from './categoriesReport';

const Finance = () => {

    return (
        <div>
            <h1>Finance Reporter</h1>

            <Tabs defaultActiveKey="statements" id="uncontrolled-tab-example">
                <Tab eventKey="import" title="Import">
                    <FileSelector />
                </Tab>
                <Tab eventKey="statements" title="Statements">
                    <TableReport />
                </Tab>
                <Tab eventKey="analytics" title="Categories">
                    <CategoriesReport />
                </Tab>
            </Tabs>


        </div>
    )
};

export default Finance;