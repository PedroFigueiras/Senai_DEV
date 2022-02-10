import '../../../src/App.css';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import clogo from '../../assets/img/Logo.png'
import Isp from '../../assets/img/spmedical.png'


export default function Medicos() {



    const [ListarConsultas, setListarConsultas] = useState([]);



    useEffect(Consultas, []);

    function Consultas() {
        axios('https://620549d2161670001741b775.mockapi.io/MEDICO', {
            headers: {
                // 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(response => {
                if (response.status === 200) {
                    setListarConsultas(response.data);
                }

            }).catch(erro => console.log(erro));

    };

    // function Consultas() {
    //     axios('http://192.168.3.158:5000/api/Consultas/medico', {
    //     headers: {
    //         'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
    //     }
    // })
    //         .then(response => {
    //             if (response.status === 200) {
    //                 setListarConsultas(response.data);
    //             }

    //         }).catch(erro => console.log(erro));

    // };
    return (
        <div>
            <body>
                <div className="App2">

                    <header className="App-header">
                        <div className='sairc'>
                            <nav>
                                <Link to="/"> <a href="">Sair</a></Link>
                            </nav>
                        </div>
                        <img class="clogo" src={clogo} alt="" />
                        <div className="divisaoc">
                            <div className="quadroazullC">
                                <h1 class="cadastrarl">Lista Medicos</h1>
                            </div>
                        </div>
                        <div class="LARANJAO">

                            {
                                ListarConsultas.map((consulta) => {

                                    return (
                                        <div key={consulta.idPaciente}>
                                            <div className="brancao">

                                                <section>
                                                    <ul className="separacao">

                                                        <li>- Médico: {consulta.MedicoNavegation.nomeMedico} </li>
                                                        <li>- Paciente: {consulta.PacienteNavigation.nomePaciente}</li>

                                                        <li>- Especialidade:{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</li>
                                                        <li>- Data/Hora:{Intl.DateTimeFormat("pt-BR", {
                                                            year: 'numeric', month: 'numeric', day: 'numeric',
                                                            hour: 'numeric', minute: 'numeric', hour12: true
                                                        }).format(new Date(consulta.dataHora))}</li>

                                                        <li>- Situação:{consulta.idSituacaoNavigation.tipoSituacao}</li>
                                                        <li>- Descrição:{consulta.descricao}</li>


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