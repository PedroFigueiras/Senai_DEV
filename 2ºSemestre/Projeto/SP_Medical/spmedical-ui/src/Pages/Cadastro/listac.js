import '../../../src/App.css';
// import axios from 'axios';
import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import clogo from '../../assets/img/Logo.png'
import Isp from '../../assets/img/spmedical.png'
import api from '../../services/api'

export default function Pacientes() {



    const [ListarConsultas, setListarConsultas] = useState([]);

    function Consultas() {
        api('/Consultas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(response => {
                if (response.status === 200) {
                    setListarConsultas(response.data);
                }

            }).catch(erro => console.log(erro));

    };

    useEffect(Consultas, []);

    return (
        <div>
            <body>
                <div className="App2">

                    <header className="App-header">
                        <div className='sairr'>
                            <nav>
                                <Link to="/"> <a href="">Sair</a></Link>
                            </nav>
                        </div>

                        <img class="clogo" src={clogo} alt="" />
                        <div className="divisaoc">
                            <div className="quadro_azullc">
                                <h1 class="cadastrarl">Consultas ADM</h1>
                            </div>
                        </div>
                        <div class="LARANJAO">
                            <div >
                                <Link to="/cadastro"><button className="btnc">Cadastro Consultas</button> </Link>

                            </div>
                            {
                                ListarConsultas.map((consulta) => {

                                    return (
                                        <div key={consulta.idPaciente}>
                                            <div className="brancao">

                                                <section className="lista">
                                                    <ul className="separacao">


                                                        <li>Paciente: {consulta.idPacienteNavigation.nomePaciente}</li>
                                                        <li>Médico: {consulta.idMedicoNavigation.nomeMedico} </li>
                                                        <li>Especialidade:{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</li>
                                                        <li>Data/Hora:{Intl.DateTimeFormat("pt-BR", {
                                                            year: 'numeric', month: 'numeric', day: 'numeric',
                                                            hour: 'numeric', minute: 'numeric', hour12: true
                                                        }).format(new Date(consulta.dataHora))}</li>
                                                        <li>Descrição:{consulta.descricao}</li>
                                                        <li>Situação:{consulta.idSituacaoNavigation.tipoSituacao}</li>


                                                    </ul>

                                                </section>


                                            </div>


                                        </div>
                                    )
                                })

                            }




                        </div>
                        <img class="spl" src={Isp} alt="" />
                    </header>
                </div>

            </body>


        </div>
    )


}