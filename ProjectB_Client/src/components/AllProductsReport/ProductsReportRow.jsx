import React, { useState, useEffect, useContext } from "react";
import { getAllProductsFromDB, getBcCodeByEmailFromDB } from "../../services/services";
import { addOrderToDB } from "../../services/services";
import { RoleStatus } from "../../context/roleStatus";
import { useAuth0 } from "@auth0/auth0-react";

export const ProductsReportRow = (props) => {
  const [AllProducts, setAllProducts] = useState([]);
  const [userBCcode, setuserBCcode] = useState([]);
  const { role, setRole } = useContext(RoleStatus);
  const { user } = useAuth0();

  const getDB = async () => {
    let result = await getAllProductsFromDB();
    let userBCcode = await getBcCodeByEmailFromDB(user.email);
    setAllProducts(result.data);
    setuserBCcode(userBCcode);
  };

  useEffect(() => {
    getDB();
  }, []);

  const handelDonationData = async (Product) => {
    await addOrderToDB(Product);
  };

  return (
    <>
      {AllProducts.length > 0 ? (
        AllProducts.map((Product) => {
          let { Code, Name, Price, Units_In_Stock, BC_code, Campaign_code, Image } = Product;
          return (
            <>
              <tr className={role !== "SA" && userBCcode === BC_code ? "table-danger" : ""}>
                <th scope="row">{Code}</th>
                <td>{Name}</td>
                <td>{Price}$</td>
                <td>{Units_In_Stock}</td>
                <td>{BC_code}</td>
                <td>{Campaign_code}</td>
                <td>
                  <img style={{ width: "50px", height: "50px", borderRadius: "30%" }} src={Image} alt="" />
                </td>
                {role === "SA" && (
                  <td>
                    <button type="button" class="btn btn-primary" onClick={() => handelDonationData(Product)}>
                      Buy & Donate
                    </button>
                  </td>
                )}
              </tr>
            </>
          );
        })
      ) : (
        <h1>There are no products.</h1>
      )}
    </>
  );
};
