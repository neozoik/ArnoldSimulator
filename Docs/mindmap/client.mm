<map version="1.0.1">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1459952803233" ID="ID_315738775" MODIFIED="1460017143736" TEXT="Client">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1459952814473" HGAP="51" ID="ID_1652895263" MODIFIED="1460119596868" POSITION="right" TEXT="Designer" VSHIFT="-67">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1460017119040" ID="ID_1692064466" MODIFIED="1460017125956" TEXT="the &quot;master&quot; UI"/>
<node CREATED="1459952877290" ID="ID_1005617905" MODIFIED="1459952881070" TEXT="creates Communication"/>
<node CREATED="1459953488847" ID="ID_1757899512" MODIFIED="1459953497499" TEXT="checks if the core exists and communicates">
<node CREATED="1459953499495" HGAP="43" ID="ID_1171511417" MODIFIED="1460017131976" TEXT="state request" VSHIFT="-12">
<font NAME="SansSerif" SIZE="11"/>
</node>
</node>
<node CREATED="1459952846113" ID="ID_944887010" MODIFIED="1459953086494" TEXT="creates Simulation"/>
<node CREATED="1459953057768" ID="ID_260819877" MODIFIED="1459953088357" TEXT="creates Visualization"/>
<node CREATED="1459953088680" ID="ID_808085478" MODIFIED="1459953107862" TEXT="everyone here has the Communication instance"/>
</node>
<node CREATED="1459952823216" HGAP="45" ID="ID_119997417" MODIFIED="1460122703259" POSITION="right" TEXT="Visualization" VSHIFT="59">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1459954209344" ID="ID_1177806783" MODIFIED="1460020725749" TEXT="asks Simulation if there&apos;s been new data">
<node CREATED="1460020726872" ID="ID_586049471" MODIFIED="1460020733384" TEXT="in the main loop">
<font NAME="SansSerif" SIZE="11"/>
</node>
</node>
<node CREATED="1459954392479" ID="ID_1961415463" MODIFIED="1460108686301" TEXT="refreshes the model if needed"/>
</node>
<node CREATED="1459952882137" HGAP="44" ID="ID_1282302855" MODIFIED="1460108869010" POSITION="left" TEXT="Communication" VSHIFT="-24">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1459952885722" HGAP="27" ID="ID_522302806" MODIFIED="1459953987909" TEXT="provides request sending API" VSHIFT="4"/>
<node CREATED="1459953152378" HGAP="38" ID="ID_4569518" MODIFIED="1459953992970" TEXT="receives protobuf-able data object" VSHIFT="8"/>
<node CREATED="1459952911810" HGAP="39" ID="ID_600658153" MODIFIED="1460017069385" TEXT="returns a future (Task&lt;TResponse&gt;)" VSHIFT="8">
<node CREATED="1459953022982" ID="ID_1618668423" MODIFIED="1459953028267" TEXT="future holds the socket"/>
<node CREATED="1459953028494" ID="ID_36137656" MODIFIED="1459953031875" TEXT="this makes it threadsafe"/>
</node>
</node>
<node CREATED="1459953843101" HGAP="74" ID="ID_1524367672" MODIFIED="1460122707723" POSITION="left" TEXT="Simulation" VSHIFT="22">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1459953851180" HGAP="43" ID="ID_1434020602" MODIFIED="1459953979556" TEXT="used for simulation control" VSHIFT="-14"/>
<node CREATED="1459953858780" HGAP="56" ID="ID_5236234" MODIFIED="1460017032376" TEXT="load blueprint/start/stop/pause" VSHIFT="-1"/>
<node CREATED="1460017232043" HGAP="70" ID="ID_1103574070" MODIFIED="1460017252120" TEXT="sync" VSHIFT="10">
<node CREATED="1460017253724" ID="ID_1926603243" MODIFIED="1460017262425" TEXT="uses Communication"/>
<node CREATED="1460017262668" ID="ID_9851985" MODIFIED="1460045062059" TEXT="asks Core for new data">
<node CREATED="1460017290924" ID="ID_618298256" MODIFIED="1460017297869" TEXT="using current filters">
<font NAME="SansSerif" SIZE="11"/>
</node>
<node CREATED="1460045064335" ID="ID_34977654" MODIFIED="1460045073246" TEXT="limits to avoid spamming">
<font NAME="SansSerif" SIZE="11"/>
</node>
<node CREATED="1460045086000" ID="ID_609835648" MODIFIED="1460045099173" TEXT="no extra threads for this now">
<font NAME="SansSerif" SIZE="11"/>
</node>
<node CREATED="1460020687126" ID="ID_666642158" MODIFIED="1460020695292" TEXT="waits for the last operation to finish"/>
</node>
<node CREATED="1460020740232" ID="ID_726880628" MODIFIED="1460020748487" TEXT="when completed, sets a flag for Visualization"/>
</node>
<node CREATED="1459952825505" HGAP="64" ID="ID_144467439" MODIFIED="1460017229478" TEXT="Model" VSHIFT="110">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1459953818619" ID="ID_683002720" MODIFIED="1459953886434" TEXT="represents the remote simulation state"/>
<node CREATED="1460017213114" ID="ID_1231816565" MODIFIED="1460017222287" TEXT="only the state, no dynamics"/>
</node>
</node>
</node>
</map>