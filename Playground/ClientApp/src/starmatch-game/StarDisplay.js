import React, { useState } from 'react';
import {range} from './utils/math';

const StarDisplay = ({count}) => {
    return (
      range(1, count).map(starId => 
        <div key={starId} className="star" />
      )
    )
};

export default StarDisplay;