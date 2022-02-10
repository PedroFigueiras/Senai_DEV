import '../../../src/App.css';
// import clogo from '../../assets/img/Logo.png'
// import moca from '../../assets/img/moca cadastro.png'
// import Isp from '../../assets/img/spmedical.png'

import { React, Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';


export default class cadastrar extends Component {
    constructor(props) {
        super(props);

        this.state = {
            IdPaciente: 0,
            IdMedico: 0,
            DataHora: new Date(),
            situacao: '',
            listaPacientes: [],
            listaMedicos: [],
            isLoading: false,
        };
    }

    
    PacienteLista = () => {

        axios('https://620549d2161670001741b775.mockapi.io/Paciente', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {

                if (resposta.status === 200) {

                    this.setState({ listaPacientes: resposta.data });
                    console.log(this.state.listaPacientes);
                }
            })

            .catch((erro) => console.log(erro));

    };

    MedicosLista = () => {

        axios('http://192.168.18.9:5000/api/Medicos', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {

                if (resposta.status === 200) {

                    this.setState({ listaMedicos: resposta.data });
                    console.log(this.state.listaMedicos);
                }
            })

            .catch((erro) => console.log(erro));
    };


    cadastrarConsulta = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let consulta = {
            IdPaciente: this.state.IdPaciente,
            IdMedico: this.state.IdMedico,
            DataHora: new Date(this.state.DataHora),
            IdSituacao: 3
        };

        axios.post('https://620549d2161670001741b775.mockapi.io/CONSULTA', consulta, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                console.log(resposta)
                if (resposta.status === 201) {
                    this.setState({ isLoading: false });
                    this.props.history.push('/listarconsulta')
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })

    };

    atualizaStateCampo = (campo) => {
        console.log(campo.target.name)
        console.log(campo.target.value)
        this.setState({ [campo.target.name]: campo.target.value });
    };



    // cadastrarConsulta = (event) => {
    //     event.preventDefault();
    //     this.setState({ isLoading: true });

    //     let consulta = {
    //         IdPaciente: this.state.IdPaciente,
    //         IdMedico: this.state.IdMedico,
    //         DataHora: new Date(this.state.DataHora),
    //         IdSituacao: 3
    //     };

    //     axios.post('http://192.168.3.158:5000/api/Consultas', consulta, {
    //         headers: {
    //             Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
    //         },
    //     })
    //         .then((resposta) => {
    //             console.log(resposta)
    //             if (resposta.status === 201) {
    //                 this.setState({ isLoading: false });
    //                 this.props.history.push('/listarconsulta')
    //             }
    //         })
    //         .catch((erro) => {
    //             console.log(erro);
    //             this.setState({ isLoading: false });
    //         })

    // };

    // PacienteLista = () => {

    //     axios('http://192.168.3.158:5000/api/Pacientes', {
    //         headers: {
    //             Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
    //         },
    //     })
    //         .then((resposta) => {

    //             if (resposta.status === 200) {

    //                 this.setState({ listaPacientes: resposta.data });
    //                 console.log(this.state.listaPacientes);
    //             }
    //         })

    //         .catch((erro) => console.log(erro));

    // };



    // MedicosLista = () => {

    //     axios('http://192.168.3.158:5000/api/Medicos', {
    //         headers: {
    //             Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
    //         },
    //     })
    //         .then((resposta) => {

    //             if (resposta.status === 200) {

    //                 this.setState({ listaMedicos: resposta.data });
    //                 console.log(this.state.listaMedicos);
    //             }
    //         })

    //         .catch((erro) => console.log(erro));
    // };





    componentDidMount() {
        this.PacienteLista();
        this.MedicosLista();
    }



    render() {
        return (
            <div>

                <body className="App3">

                    <main>

                        <div className='sairc'>
                            <nav>
                                <Link to="/"> <a href="">Sair</a></Link>
                            </nav>
                        </div>

                        <div >
                            <Link  to="/listarconsulta"><button className='brlogiC'>Listar Consultas</button> </Link>
                        </div>


                        <div className="form-cadastro-c">
                            <div className="quadro_azullc">
                                <h1 class="cadastrarl">Consultas ADM</h1>
                            </div>
                            <section className="formulario-c">
                                <form onSubmit={this.cadastrarConsulta} >

                                    <select className="paci"
                                        required
                                        value={this.state.IdPaciente}

                                        onChange={this.atualizaStateCampo}
                                        name="IdPaciente"
                                    >

                                        <option value="0">Selecione o Paciente.</option>


                                        {this.state.listaPacientes.map((p) => {

                                            return (
                                                <option key={p.idPaciente} value={p.idPaciente}>
                                                    {p.nomePaciente}
                                                </option>
                                            );
                                        })}

                                    </select>
                                    <select className="paci"

                                        value={this.state.IdMedico}

                                        onChange={this.atualizaStateCampo}
                                        name="IdMedico"
                                        required >

                                        <option value="0">Selecione o Médico.</option>


                                        {this.state.listaMedicos.map((p) => {
                                            return (

                                                <option key={p.idMedico} value={p.idMedico}>
                                                    {p.nomeMedico}
                                                </option>
                                            );
                                        })}

                                    </select>


                                    <input type="datetime-local" placeholder="Data:"
                                        name="DataHora" value={this.DataHora}
                                        onChange={this.atualizaStateCampo} required />

                                    {this.state.isLoading === true && (
                                        <button type="submit" disabled>
                                            Loading.......{' '}
                                        </button>
                                    )}

                                    {this.state.isLoading === false && (
                                        <div className="btn-cadastro-c">
                                            <input type="submit" value="Cadastrar" />
                                        </div>
                                    )}


                                </form>
                            </section>
                        </div>


                    </main>

                </body>

            </div>
        )
    }
}
