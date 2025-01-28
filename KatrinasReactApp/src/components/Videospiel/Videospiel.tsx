import { VideospielWrapper } from "./Videospiel.styled";
import { VideospielData } from "../../types/VideospielData.types";

const Videospiel = (props: { videospiel: VideospielData }) => {
  return (
    <VideospielWrapper>
      <div>
        {props.videospiel.Titel} ({props.videospiel.Erscheinungsjahr}) :
        {props.videospiel.Beschreibung}
      </div>
    </VideospielWrapper>
  );
};

export default Videospiel;
