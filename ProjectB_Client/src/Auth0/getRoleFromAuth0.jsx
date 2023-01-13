import React, { useEffect, useContext } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { RoleStatus } from "./../context/roleStatus";
import { getRolesData } from "../../src/services/services";
//import { UserDataContext } from "./../../context/userData";

export const GetRoleFromAuth0 = (props) => {
  const { role, setRole } = useContext(RoleStatus);
  //const { setUserInfo } = useContext(UserDataContext);
  const { user } = useAuth0();

  const handleRoles = async () => {
    let userId = user.sub;
    let RoleData = await getRolesData(userId);
    if (Object.keys(RoleData).length === 0) {
      setRole("");
    } else {
      let RoleName = RoleData[0].name;
      setRole(RoleName);
    }
  };

  useEffect(() => {
    handleRoles();
  }, []);

  //   const handleUserInfo = async () => {
  //     if (role === "N.P.O" || role === "company" || role === "Activist") {
  //       let userInfo = await getUserInfoData(user.email, role);
  //       let userInfoFullData = userInfo[0];
  //       setUserInfo(userInfoFullData);
  //     }
  //   };

  //   useEffect(() => {
  //     handleUserInfo();
  //   }, [role]);

  // return <div>{role}</div>;
};
