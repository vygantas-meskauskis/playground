import React, { useState } from 'react';
import { Table } from 'react-bootstrap';
import FileSelector from './FileSelector';
import {TableReport} from './TableReport';

const Finance = () => {

    return (
        <div>
            <h1>Finance Reporter</h1>
            
            <FileSelector />
            <TableReport />
      </div>
    )
};

export default Finance;