import { apiFetch } from '@/services/api'
import type { GameState, StartGameRequest, SubmitTurnRequest, TurnResult } from '@/types/game'

export function startGame(data: StartGameRequest) {
  return apiFetch<GameState>('/game/start', {
    method: 'POST',
    body: JSON.stringify(data)
  })
}

export function submitTurn(data: SubmitTurnRequest) {
  return apiFetch<TurnResult>('/game/submit-turn', {
    method: 'POST',
    body: JSON.stringify(data)
  })
}

export function getGameState(sessionId: number) {
  return apiFetch<GameState>(`/game/${sessionId}`)
}