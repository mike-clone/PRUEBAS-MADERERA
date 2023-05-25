describe ("Login",()=>{
     beforeEach(()=>{
     cy.visit("http://localhost:8081/")
     cy.get(".contact-info i").find('a').should("have.text","omarlujan.h@gmail.com")
    })
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Devuelve false para evitar que Cypress falle la prueba
        return false;
      });
    it("Login incorrecto",()=>{
        cy.get("#navbar ul li").eq(2).click()
        cy.get(".login-container").find('h1').should("have.text","Login Form")
        cy.get(".btn").click()
        cy.get('.needs-validation').should('have.class', 'was-validated'); 
        cy.get('.invalid-feedback').should('be.visible')
        cy.get("#valid_username").type("omar@upn.pe")
        cy.get("#valid_password").type("123")
        cy.get(".btn").click()
        cy.get(".alert-danger").should('be.visible')
        cy.get("#valid_username").type("omar@hotmail.com")
        cy.get("#valid_password").type("&*")
        cy.get(".btn").click()
        cy.get(".alert-danger").should('be.visible')
        cy.get("#valid_username").type("omarlux@outlook.es")
        cy.get("#valid_password").type("mms")
        cy.get(".btn").click()
        cy.get(".alert-danger").should('be.visible')
    })
    it("Login correcto",()=>{
     cy.get("#navbar ul li").eq(2).click()
     cy.get(".login-container").find('h1').should("have.text","Login Form")
     cy.get("#valid_username").type("omar@gmail.com")
     cy.get("#valid_password").type("123")
     cy.get(".btn").click()
     cy.get(".contact-info i").find('a').should("have.text","omar@gmail.com")
    })
})

