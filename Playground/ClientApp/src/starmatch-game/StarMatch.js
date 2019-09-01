import React, { useState } from 'react';
import './style/StarMatch.css';
import {range, random, sum} from './utils/math.js';
import StarDisplay from './StarDisplay';

const PlayNumber = props => (
  <button 
    className="number" 
    onClick={() => console.log("num: " + props.number)}
    >
    {props.number}
  </button>
);


const StarMatch = () => {
    const [stars, setStars] = useState(random(1,9));
    const [availableNums, setAvailableNums] = useState([1,2,3,4]);
    const [candidateNums, setCandidateNums] = useState([2,3]);

    var candidatesAreWrong = sum(candidateNums) > stars;
    
    const numberStatus = (number) => {
      if (!availableNums.includes(number)){
        return "used";
      }

      if (candidateNums.includes(number)){
        return candidatesAreWrong ? "wrong" : "candidate";
      }

      return "available";
    }

    return (
      <div className="game">
        <div className="help">
          Pick 1 or more numbers that sum to the number of stars
        </div>
        <div className="body">
          <div className="left">
            <StarDisplay count={stars} />
          </div>
          <div className="right">
            {
                range(1,9).map(number => 
                    <PlayNumber 
                      key={number} 
                      number={number}
                      status={numberStatus(number)}/>
                    )
            }
          </div>
        </div>
        <div className="timer">Time Remaining: 10</div>
      </div>
    );
  };
  
  export default StarMatch;