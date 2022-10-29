import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { surveys: [], loading: true };
    }

    componentDidMount() {
        this.populateSurveyData();
    }

    static renderSurveyTable(surveys) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <tbody>
                    {surveys.map(survey =>
                        <tr>
                            <td>{survey.name}</td>
                            <td>{survey.description}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... </em></p>
            : App.renderSurveyTable(this.state.surveys);

        return (
            <div>
                <h1 id="tabelLabel" >Surveys</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateSurveyData() {
        const response = await fetch("surveys");
        const data = await response.json();
        this.setState({ surveys: data, loading: false });
    }
}
