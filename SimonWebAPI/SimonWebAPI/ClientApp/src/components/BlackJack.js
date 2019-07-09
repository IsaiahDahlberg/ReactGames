import React, { Component } from 'react';
import "./BlackJack.css";


class RenderButtons extends React.Component {
    constructor(props) {
        super(props);

    }
    render() {
        return (
            <div>
                <DealButton InGame={this.props.InGame} onClick={() => this.props.onClick(0)} />
                <HitButton InGame={this.props.InGame} onClick={() => this.props.onClick(1)} />
                <StayButton InGame={this.props.InGame} onClick={() => this.props.onClick(0)} />
            </div>
        );
    }
}

function DealButton(props){
    if (!props.InGame) {
        return <button onClick={props.onClick}>Deal</button>
    } else {
        return null;
    }
}

function HitButton(props) {
    if (props.InGame) {
        return <button onClick={props.onClick}>Hit</button>
    } else {
        return null;
    }
}

function StayButton(props) {
    if (props.InGame) {
        return <button onClick={props.onClick}>Stay</button>
    } else {
        return null;
    }
}


class DisplayHands extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>

                <ul>
                    <li>Player</li>
                    {this.props.Player.map(function (listValue) {
                        return <li> <img src="./10C.png" /> </li>;
                    })}
                </ul>

                <ul>
                    <li>Dealer</li>
                    {this.props.Dealer.map(function (listValue) {
                        return <li>{listValue}</li>;
                    })}
                </ul>

            </div>
       );
    }
}

export class  BlackJack extends React.Component {
    constructor() {
        super();
        this.state = {
            InGame: true,
            Status: "asdDeal",
            Player: [],
            Dealer: []
        }
    }

    PlayRound(i) {
        fetch("api/BlackJack/PlayRound/" + i).then(response => response.json())
            .then(data => { alert({ data }) });
      
    }

    GetHands() {
        fetch("api/blackjack/GetPlayerHand").then(response => response.json())
            .then(data => { this.setState({ Player: data }) });

        fetch("api/blackjack/getDealerhand").then(response => response.json())
            .then(data => { this.setState({ Dealer: data }) });
    }


    render() {
        return (
            <div>
                <p>Black Jack</p>
                <h4>{this.state.Status}</h4>
                <DisplayHands Player={this.state.Player} Dealer={this.state.Dealer} />
                <RenderButtons InGame={this.state.InGame} onClick={i => this.PlayRound(i)} />
                <button onClick={() => this.PlayRound(1)}>Hit</button>
                <button onClick={() => this.PlayRound(0)}>Stay</button>
                <button onClick={() => this.GetHands()}> Get Hands</button>
            </div>
        );
    }


}