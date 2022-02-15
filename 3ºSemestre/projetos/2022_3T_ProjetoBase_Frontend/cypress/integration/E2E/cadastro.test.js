describe('Descricao', () => {

    beforeEach(() => {
        cy.visit('http://localhost:3000/')
    })



    it('Deve logar e inseir a imagem carregando a OCR no input de texto, CRIAR E EXCLUIR', () => {

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click();


        cy.get('.input__login').first().type('tsuka@email.com')
        cy.get('.input__login').last().type('123456789')
        cy.get('.btn__login').click()

        
        cy.get('#nomePatrimonio').type('Equipamento')
        cy.get('input[type=file]').first().selectFile('src/assets/test/equipamento.jpeg');
        cy.get('#codigoPatrimonio').should('have.value', '1202362')
        cy.get('input[type=file]').last().selectFile('src/assets/test/equipamento.jpeg');
        cy.get('.btn__cadastro').click()
        cy.wait(5000)

        cy.get('.excluir').last().click()

    })

})