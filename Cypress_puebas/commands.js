// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })

Cypress.Commands.add("visitarURL", (ruta) => {
  const ip = "192.168.100.6"; // Reemplaza con tu dirección IP
  const puerto = "8081"; // Reemplaza con tu número de puerto

  const url = `http://${ip}:${puerto}${ruta}`;

  cy.visit(url);
});

Cypress.Commands.add("logIn", (ruta) => {
  cy.get("#valid_username").type("daniel@gmail.com");
  cy.get("#valid_password").type("123");
  cy.get(".btn").click();
});

// administrador
 Cypress.Commands.add("logInAdmin",(url,email,password)=>{
    //abrir la pagina
    Cypress.on("uncaught:exception", (err, runnable) => {
        return false;
      });
     cy.visit(url)
     cy.get("#navbar ul li").eq(2).click()
     cy.get(".login-container").find('h1').should("have.text","Login Form")
     cy.get("#valid_username").type(email)
     cy.get("#valid_password").type(password)
     cy.get(".btn").click()
     cy.get(".contact-info i").find('a').should("have.text",email)

  });
  Cypress.Commands.add("guardarId", () => {
    cy.get("#navbar ul li.dropdown").eq(2).find('ul li').last().find('a').click({force:true});
    cy.contains("MIS COMPRAS").should("have.text","MIS COMPRAS")
    return cy.get(".table tbody tr").then((trElements) => {
       const trCount= trElements.length;
       return trCount;
    });
    
  });
  