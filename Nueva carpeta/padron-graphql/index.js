

import mysqql from 'mysql2/promise';

const db = mysqql.createPool({
    host:'127.0.0.1',
    user:'root',
    password:'',
    database:'padrom_db',
});
const typeDefs = `#graphql
    type Pasajero {
        ci: String
        nombres: String
        apellidos:String
        celular:String
        frecuente:Boolean
    }   
    type Query {
        Pasajero(ci:String!):Pasajero
        Pasajeros:[Pasajero]
    }
    type Matatiom { 
        registrarPasajero(
            ci: String!
            nombres: String!
            apellidos: String!
            celular: String!
            frecuente: Boolean = false

        ): Pasajero
    }
`;
const resolvers={
Query:{
    pasajero: async(_,{ci}) =>{ const [rows] = await db.query('SELECT * FROM pasajeros WHERE ci= ?',[ci]);
        if (rows.length === 0) throw new Error('PASAJER  NO RESGISTRADO');
        return {...rows[0], frecuente: Boolean(rows[0],frecuente)};
    },
    pasajero:async () =>{
        const [rows] =await  db.query ('SELECT *FROM  pasajeros');
        return  rows.map(p => ({p,frecuente: Boolean(p.frecuente)}));
    }
},

}