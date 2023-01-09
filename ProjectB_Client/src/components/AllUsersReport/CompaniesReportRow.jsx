import React, { useState, useEffect } from "react";
import { getAllCompaniesFromDB } from "../../services/services";

export const ActivistsReportRow = (props) => {
  const [AllCompanies, setAllCompanies] = useState([]);

  const getDB = async () => {
    let result = await getCompaniestsFromDB();
    setAllCompanies(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  return (
    <>
      {AllCompanies.length > 0 ? (
        AllCompanies.map((Company) => {
          let { Name, Email, Image } = Company;
          return (
            <>
              <tr>
                <td>{Name}</td>
                <td>{Email}</td>
                <td>{Image}</td>
              </tr>
            </>
          );
        })
      ) : (
        <h1>There are no Companies.</h1>
      )}
    </>
  );
};
